using kita.Model;
using Microsoft.EntityFrameworkCore;

namespace kita.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Playlist> Playlists { get; set; } = null!;
    public DbSet<Song> Songs { get; set; } = null!;
    
    
}