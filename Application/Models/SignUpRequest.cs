namespace Application.Models;

public class SignUpRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RoleId { get; set; }
    public string FireBaseId { get; set; }
    public string Email { get; set; }
}