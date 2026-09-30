using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models.Entities;
using server.Data;
using server.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class UserController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public UserController(AppDbContext dbContext) =>
        _dbContext = dbContext;   

    [HttpGet]
    public async Task<List<UserResponse>> Get()
    {
        return await _dbContext.Users
            .Select(user => new UserResponse
            {
                Id = user.Id,
                // Name = user.Name,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Zipcode = user.Zipcode,
                Country = user.Country,
                State = user.State,
                City = user.City,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            }).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<UserResponse?> GetById(int id)
    {
        return await _dbContext.Users
            .Where(user => user.Id == id)
            .Select(user => new UserResponse
            {
                Id = user.Id,
                // Name = user.Name,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Zipcode = user.Zipcode,
                Country = user.Country,
                State = user.State,
                City = user.City,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            })
            .FirstOrDefaultAsync();
    }

    // [AllowAnonymous]
    // [HttpPost]
    // public async Task<ActionResult> Create([FromBody] CreateUserRequest request)
    // {
    //     if(string.IsNullOrWhiteSpace(request.Name) || 
    //        string.IsNullOrWhiteSpace(request.Email) || 
    //        string.IsNullOrWhiteSpace(request.Password)
    //     )
    //     {
    //         return BadRequest("Invalid Request");
    //     }

    //     if(await _dbContext.Users.AnyAsync(u => u.Email == request.Email))
    //     {
    //         return Conflict("Email already exists.");
    //     }

    //     User user = new User
    //     {
    //         Name = request.Name,
    //         Email = request.Email,
    //         PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password, workFactor: 12),
    //     };

    //     await _dbContext.Users.AddAsync(user);
    //     await _dbContext.SaveChangesAsync();

    //     return CreatedAtAction(nameof(GetById), new { id = user.Id}, new
    //     {
    //         user.Id,
    //         user.Name,
    //         user.Email
    //     });
    // }

    // [HttpPut]
    // public async Task<ActionResult> Update([FromBody] UpdateUserRequest request)
    // {
    //     var callerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value 
    //         ?? User.FindFirst("sub")?.Value!);

    //     if(callerId != request.Id)
    //     {
    //         return Forbid();
    //     }

    //     var existingUser = await _dbContext.Users.FindAsync(request.Id);

    //     if(existingUser is null)
    //     {
    //         return NotFound();
    //     }

    //     existingUser.Name = request.Name;
    //     existingUser.Email = request.Email;

    //     if (!string.IsNullOrWhiteSpace(request.Password))
    //     {
    //         existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password, 12);
    //     }

    //     await _dbContext.SaveChangesAsync();

    //     return Ok();
    // }


    // TODO: CREATE A DELETE USER REQUEST D(ata)T(ransfer)O(bject)
    // [HttpDelete("{id}")]
    // public async Task<ActionResult> Delete(int id)
    // {
    //     var user = await _dbContext.Users.FindAsync(id);
    //     if(user is null)
    //     {
    //         return NotFound();
    //     }

    //     _dbContext.Users.Remove(user);
    //     await _dbContext.SaveChangesAsync();

    //     return Ok();
    // }
}