using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kita.Model;

[Table("Users")]
public class User
{
    [Key] [Required] public int Id { get; set; }
    [Required] [MaxLength(100)] public string Username { get; set; } = string.Empty;
    [Required] [MaxLength(100)] public string FullName { get; set; } = string.Empty;
    [Required] [MaxLength(100)] public string Email { get; set; } = string.Empty;
    [Required] [MaxLength(100)] public string Password { get; set; } = string.Empty;
    [Required] [MaxLength(100)] public string Role { get; set; } = "User"; // Default role is User
    [Required] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    
    

}