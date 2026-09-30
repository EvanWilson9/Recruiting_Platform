using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models.Api;
using server.Services;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel request)
    {
        var result = await _jwtService.Authenticate(request);
        if (result is null)
        {
            return Unauthorized();
        }

        var (rawRefreshToken, _) = await _jwtService.GenerateRefreshToken(result.UserId);
        SetRefreshCookie(rawRefreshToken);

        return result;
    }
    
    [AllowAnonymous]
    [HttpPost("refresh")]
    public async Task<ActionResult<LoginResponseModel>> Refresh()
    {
        if (!Request.Cookies.TryGetValue("refreshToken", out var rawToken) || rawToken is null)
        {
            return Unauthorized();
        }

        var result = await _jwtService.RefreshAccessToken(rawToken);
        if (result is null)
        {
            return Unauthorized();
        }

        SetRefreshCookie(result.Value.newRawRefreshToken);
        return result.Value.response;
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<ActionResult> Logout()
    {
        if (Request.Cookies.TryGetValue("refreshToken", out var rawToken) && rawToken is not null)
        {
            await _jwtService.RevokeRefreshToken(rawToken);
        }

        Response.Cookies.Delete("refreshToken");
        return Ok();
    }

    private void SetRefreshCookie(string rawToken)
    {

        var options = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddDays(7),
            Path = "/api/auth"
        };

        Response.Cookies.Append("refreshToken", rawToken, options);
    }
}