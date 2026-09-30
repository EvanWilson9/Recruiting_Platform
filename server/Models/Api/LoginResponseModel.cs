namespace server.Models.Api;

public class LoginResponseModel
{
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? Email { get; set; }
    public string? AccessToken { get; set; }
    public int ExpiresIn { get; set; }
}