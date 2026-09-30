namespace server.Models.Api;

public class LoginRequestModel
{
    public string? FirstName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}