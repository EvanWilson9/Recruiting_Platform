namespace server.DTOs;

public class EducationResponse
{
    public int PlayerSchoolId { get; set; }
    public int SchoolId { get; set; }
    
    // School Details (joined from School entity)
    public string SchoolName { get; set; } = string.Empty;
    public string? LogoUrl { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }

    // Academic Details
    public int StartYear { get; set; }
    public int? StartMonth { get; set; }

    public int? EndYear { get; set; }
    public int? EndMonth { get; set; }
    
    public string? Level { get; set; }
    public double? Gpa { get; set; }
    public int? SAT { get; set; }
    public int? ACT { get; set; }
    public bool IsCurrent { get; set; }
}