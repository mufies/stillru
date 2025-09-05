using kita.Data;

namespace kita.Repository;

public class SongRepository : ISongRepository
{
    private readonly AppDbContext _context;
    
    public SongRepository(AppDbContext context)
    {
        _context = context;
    }

    public Song CreateSong(Song song)
    {
        _context.Songs.Add(song);
        _context.SaveChanges();
        return song;
    }
    public Song? GetSongById(int id)
    {
        return _context.Songs.FirstOrDefault(s => s.Id == id);
    }
    public bool UpdateSong(Song song)
    {
        var existing = _context.Songs.FirstOrDefault(s => s.Id == song.Id);
        if (existing is null) return false;
        existing.Title = song.Title;
        existing.Artist = song.Artist;
        existing.Album = song.Album;
        existing.Genre = song.Genre;
        existing.Duration = song.Duration;
        existing.ImgSrc = song.ImgSrc;
        existing.AudioSrc = song.AudioSrc;
        existing.UserId = song.UserId;
        _context.SaveChanges();
        return true;
    }
    public bool DeleteSong(int id)
    {
        var song = _context.Songs.FirstOrDefault(s => s.Id == id);
        if (song is null) return false;

        _context.Songs.Remove(song);
        _context.SaveChanges();
        return true;
    }

    public List<Song> GetSongsByArtist(string artist)
    {
        return _context.Songs.Where(s => s.Artist == artist).ToList();
    }
    public List<Song> GetSongsByAlbum(string album)
    {
        return _context.Songs.Where(s => s.Album == album).ToList();
    }

    public List<Song> GetSongsByGenre(string genre)
    {
        return _context.Songs.Where(s => s.Genre == genre).ToList();
    }
    public List<Song> GetSongsByTitle(string title)
    {
        return _context.Songs.Where(s => s.Title.Contains(title)).ToList();
    }

    public List<Song> GetTopNSongs(int n)
    {
        return _context.Songs.Take(n).ToList();
    }
}