using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models.Entities;

[Table("players")]
public class Player
{
    [Key]
    public int PlayerId { get; set; }

    // Foreign Key Declaration
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    public string? Headline { get; set; }
    public string? About { get; set; }

    public string? PrimaryPosition { get; set; }
    public string? SecondaryPosition { get; set; }

    public int? ClassYear { get; set; }

    public double? Height { get; set; } //inches
    public double? Weight { get; set; } //pounds
    
    public double? BenchPress { get; set; }
    public double? BackSquat { get; set; }
    public double? PowerClean { get; set; }
    public double? VerticalJump { get; set; }
    public double? BroadJump { get; set; }
    public double? FortyYardDash { get; set; }

    public string? ProfileImage { get; set; }
    public string? BannerImage { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Collection Navigation Properties
    public virtual ICollection<AthleticCareer> AthleticCareers { get; set; } = [];
    public virtual ICollection<PlayerSchool> PlayerSchools { get; set; } = [];
}