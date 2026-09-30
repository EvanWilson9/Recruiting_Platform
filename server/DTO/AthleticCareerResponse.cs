namespace server.DTO;

public class AthleticCareerResponse
{
    public int AthleticCareerId { get; set; }
    public int PlayerId { get; set; }
    public string? SchoolName { get; set; }
    public string? Sport { get; set; }
    public string? Level { get; set; }
    
    public int StartYear { get; set; }
    public int? StartMonth { get; set; }

    public int? EndYear { get; set; }
    public int? EndMonth { get; set; }
}