namespace c_sharp.Models.User;
public class User
{
    public Guid UserId { get; set; }
    public required string Email { get; set; }
    public required string HashPassword { get; set;}
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
}