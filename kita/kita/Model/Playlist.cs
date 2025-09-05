using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kita.Model;

[Table("Playlists")]
public class Playlist
{ 

    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string ImgSrc { get; set; } = string.Empty; 
    [Required]
    [ForeignKey("UserId")]
    public int UserId { get; set; } // Foreign key to User
    
    public ICollection<Song> Songs { get; set; } = [];

    
    
    
}