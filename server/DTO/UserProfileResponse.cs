namespace server.DTO;

public class UserProfileResponse
{
    public int Id { get; set; }

    // public string? Name { get; set; } = "";
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;

    public string? Email { get; set; } = string.Empty;
    public string? Phone { get; set; } = string.Empty;

    public string? Zipcode { get; set; } = string.Empty;
    public string? Country { get; set; } = string.Empty;
    public string? State { get; set; } = string.Empty;
    public string? City { get; set; } = string.Empty;
    
    public string? Role { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    // User fields
    public int UserId { get; set; }

    // Player specific fields
    public int PlayerId { get; set; }
    public string? Headline { get; set; }
    public string? About { get; set; }
    public string? PrimaryPosition { get; set; }
    public string? SecondaryPosition { get; set; }
    public int? ClassYear { get; set; }
    public double? Height { get; set; }
    public double? Weight { get; set; }

    // Athletic stats
    public double? BenchPress { get; set; }
    public double? BackSquat { get; set; }
    public double? PowerClean { get; set; }
    public double? VerticalJump { get; set; }
    public double? BroadJump { get; set; }
    public double? FortyYardDash { get; set; }

    // Media
    public string? ProfileImage { get; set; }
    public string? BannerImage { get; set; }
}