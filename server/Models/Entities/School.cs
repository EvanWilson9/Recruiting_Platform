using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models.Entities;

[Table("schools")]
public class School
{
    [Key]
    public int SchoolId { get; set; }
    public string Name { get; set; } = "";
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Division { get; set; } // NCAA D1, D2, D3, NAIA, High School, etc.
    public string? LogoUrl { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}