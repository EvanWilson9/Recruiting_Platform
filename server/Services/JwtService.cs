using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server.Data;
using server.Models.Api;
using server.Models.Entities;

namespace server.Services;

public class JwtService
{

    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public JwtService(AppDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public async Task<LoginResponseModel?> Authenticate(LoginRequestModel request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            return null;
        }

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user is null)
        {
            return null;
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return null;
        }

        var tokenValidityMins = _configuration.GetValue<int>("JwtConfig:TokenValidityMins");

        return new LoginResponseModel
        {
            UserId = user.Id,
            FirstName = user.FirstName,
            AccessToken = GenerateAccessToken(user),
            Email = user.Email!,
            ExpiresIn = tokenValidityMins * 60
        };
    }

    public async Task<(string rawToken, RefreshToken entity)> GenerateRefreshToken(int userId)
    {
        var rawToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        var hashed = BCrypt.Net.BCrypt.HashPassword(rawToken);

        var entity = new RefreshToken
        {
            UserId = userId,
            Token = hashed,
            ExpiresAt = DateTime.UtcNow.AddDays(7),
        };

        _dbContext.RefreshTokens.Add(entity);
        await _dbContext.SaveChangesAsync();

        return (rawToken, entity);
    }

    public string GenerateAccessToken(User user)
    {
        var issuer = _configuration["JwtConfig:Issuer"];
        var audience = _configuration["JwtConfig:Audience"];
        var key = _configuration["JwtConfig:Key"];
        var tokenValidityMins = _configuration.GetValue<int>("JwtConfig:TokenValidityMins");
        var expiry = DateTime.UtcNow.AddMinutes(tokenValidityMins);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        ]),
            Expires = expiry,
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key!)),
                SecurityAlgorithms.HmacSha512Signature),
        };

        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(handler.CreateToken(tokenDescriptor));
    }

    public async Task<(LoginResponseModel response, string newRawRefreshToken)?> RefreshAccessToken(string rawToken)
{
    var candidates = await _dbContext.RefreshTokens
        .Include(rt => rt.User)
        .Where(rt => rt.RevokedAt == null && rt.ExpiresAt > DateTime.UtcNow)
        .ToListAsync();

    RefreshToken? match = null;
    foreach (var candidate in candidates)
    {
        if (BCrypt.Net.BCrypt.Verify(rawToken, candidate.Token))
        {
            match = candidate;
            break;
        }
    }

    if (match is null)
    {
        return null;
    }

    // Rotate: revoke the old token, issue a new one
    match.RevokedAt = DateTime.UtcNow;

    var (newRawToken, _) = await GenerateRefreshToken(match.UserId);
    await _dbContext.SaveChangesAsync();

    var tokenValidityMins = _configuration.GetValue<int>("JwtConfig:TokenValidityMins");

    var response = new LoginResponseModel
    {
        UserId = match.UserId,
        Email = match.User.Email!,
        AccessToken = GenerateAccessToken(match.User),
        ExpiresIn = tokenValidityMins * 60
    };

    return (response, newRawToken);
}

public async Task RevokeRefreshToken(string rawToken)
{
    var candidates = await _dbContext.RefreshTokens
        .Where(rt => rt.RevokedAt == null)
        .ToListAsync();

    foreach (var candidate in candidates)
    {
        if (BCrypt.Net.BCrypt.Verify(rawToken, candidate.Token))
        {
            candidate.RevokedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
            return;
        }
    }
}
}