using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models.Entities;
using server.Data;
using server.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using server.DTOs;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class ProfileController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public ProfileController(AppDbContext dbContext) =>
        _dbContext = dbContext;

    [HttpGet("{id}")]
    public async Task<ActionResult<UserProfileResponse>> GetHeader(int id)
    {
        var profile = await _dbContext.Users
            .Where(user => user.Id == id)
            .Select(user => new UserProfileResponse
            {
                // Core User fields
                Id = user.Id,
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Zipcode = user.Zipcode,
                Country = user.Country,
                State = user.State,
                City = user.City,
                Role = user.Role,
                CreatedAt = user.CreatedAt,

                // Player profile fields
                PlayerId = user.Player != null ? user.Player.PlayerId : 0,
                Headline = user.Player != null ? user.Player.Headline : null,
                About = user.Player != null ? user.Player.About : null,
                PrimaryPosition = user.Player != null ? user.Player.PrimaryPosition : null,
                SecondaryPosition = user.Player != null ? user.Player.SecondaryPosition : null,
                ClassYear = user.Player != null ? user.Player.ClassYear : null,
                Height = user.Player != null ? user.Player.Height : null,
                Weight = user.Player != null ? user.Player.Weight : null,

                // Athletic metrics
                BenchPress = user.Player != null ? user.Player.BenchPress : null,
                BackSquat = user.Player != null ? user.Player.BackSquat : null,
                PowerClean = user.Player != null ? user.Player.PowerClean : null,
                VerticalJump = user.Player != null ? user.Player.VerticalJump : null,
                BroadJump = user.Player != null ? user.Player.BroadJump : null,
                FortyYardDash = user.Player != null ? user.Player.FortyYardDash : null,

                // Media assets
                ProfileImage = user.Player != null ? user.Player.ProfileImage : null,
                BannerImage = user.Player != null ? user.Player.BannerImage : null
            })
            .FirstOrDefaultAsync();

        if (profile is null)
        {
            return NotFound();
        }

        return Ok(profile);
    }

    [HttpGet("education/{id}")]
    public async Task<ActionResult<EducationResponse>> GetEducation(int id)
    {
        var education = await _dbContext.PlayerSchools
            .Where(ps => ps.PlayerId == id)
            .Select(ps => new EducationResponse
            {
                PlayerSchoolId = ps.PlayerSchoolId,
                SchoolId = ps.SchoolId,
        
                SchoolName = ps.School.Name,
                LogoUrl = ps.School.LogoUrl,
                City = ps.School.City,
                State = ps.School.State,

                StartYear = ps.StartYear,
                StartMonth = ps.StartMonth,
                EndYear = ps.EndYear,
                EndMonth = ps.EndMonth,
                Level = ps.Level,
                Gpa = ps.Gpa,
                SAT = ps.SAT,
                ACT = ps.ACT,
                IsCurrent = ps.IsCurrent
            })
            .ToListAsync();

        return Ok(education);
    }

    [HttpGet("career/{id}")]
    public async Task<ActionResult<List<AthleticCareerResponse>>> GetAthleticCareers(int id)
    {
        var careers = await _dbContext.AthleticCareers
            .Where(ac => ac.PlayerId == id)
            .Select(ac => new AthleticCareerResponse
            {
                AthleticCareerId = ac.AthleticCareerId,
                PlayerId = ac.PlayerId,
                SchoolName = ac.School.Name,
                Sport = ac.Sport,
                Level = ac.Level,
                StartYear = ac.StartYear,
                StartMonth = ac.StartMonth,
                EndYear = ac.EndYear,
                EndMonth = ac.EndMonth
            })
            .OrderByDescending(ac => ac.StartYear)
            .ThenByDescending(ac => ac.StartMonth)
            .ToListAsync();

        return Ok(careers);
    }
}