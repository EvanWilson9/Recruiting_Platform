using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models.Entities;

[Table("athletic_careers")]
public class AthleticCareer
{
    [Key]
    public int AthleticCareerId { get; set; }
    
    // Player Foreign Key
    public int PlayerId { get; set; }
    [ForeignKey(nameof(PlayerId))]
    public virtual Player? Player { get; set; }

    // School Foreign Key
    public int SchoolId { get; set; }
    [ForeignKey(nameof(SchoolId))]
    public virtual School? School { get; set; }

    public string? Sport { get; set; }
    public string? Level { get; set; }

    public int StartYear { get; set; }
    public int? StartMonth { get; set; }

    public int? EndYear { get; set; }
    public int? EndMonth { get; set; }
}