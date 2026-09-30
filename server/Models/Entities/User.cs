using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models.Entities;

[Table("users")]
public class User
{
    [Key]
    public int Id { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
    public required string Email { get; set; }
    public string? Phone { get; set; }

    public string? Zipcode { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }

    public string? PasswordHash { get; set; }

    public string? Role { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // 1-to-1 relationship created
    public virtual Player? Player { get; set; }
}