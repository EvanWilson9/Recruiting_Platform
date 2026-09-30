namespace server.DTO;

public class UpdateUserRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string? Password { get; set; }
}