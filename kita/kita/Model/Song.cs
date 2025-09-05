using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kita.Model;

[Table("Song")]
public class Song
{
    [Key]
    [Required]
    [Column("Id")] public int Id { get; set; }
    [Required][Column("Title")] public string Title { get; set; } = string.Empty;
    [Required][Column("Artist")] public string Artist { get; set; } = string.Empty;
    [Required][Column("Album")] public string Album { get; set; } = string.Empty;
    [Required][Column("Duration")] public int Duration { get; set; } // Duration in seconds
    [Required][Column("Genre")] public string Genre { get; set; } = string.Empty;
    [Required][Column("ImgSrc")] public string ImgSrc { get; set; } = string.Empty;
    [Required][Column("AudioSrc")] public string AudioSrc { get; set; } = string.Empty;
    
    [Required]    [ForeignKey("UserId")] public int UserId { get; set; }
    public ICollection<Playlist> Playlists { get; set; } = [];

}