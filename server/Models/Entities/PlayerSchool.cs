using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models.Entities;

[Table("player_schools")]
public class PlayerSchool
{
    [Key]
    public int PlayerSchoolId { get; set; }

    // Player Foreign Key
    public int PlayerId { get; set; }
    [ForeignKey(nameof(PlayerId))]
    public Player Player { get; set; } = null!;

    // School Foreign Key
    public int SchoolId { get; set; }
    [ForeignKey(nameof(SchoolId))]
    public School School { get; set; } = null!;

    public int StartYear { get; set; }
    public int? StartMonth { get; set; }

    public int? EndYear { get; set; }
    public int? EndMonth { get; set; }

    public string? Level { get; set; } // High School, College, JUCO, Prep, etc.

    public double? Gpa { get; set; }
    public int? SAT { get; set; }
    public int? ACT { get; set; }

    public bool IsCurrent { get; set; } = false;
}