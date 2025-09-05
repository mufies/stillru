using kita.Data;
using Microsoft.EntityFrameworkCore;

namespace kita.Repository;

public class PlaylistRepository : IPlaylistRepository
{
    private readonly AppDbContext _context;
    
    public PlaylistRepository(AppDbContext context)
    {
        _context = context;
    }
    public Playlist CreatePlaylist(Playlist playlist)
    {
        _context.Playlists.Add(playlist);
        _context.SaveChanges();
        return playlist;
    }
    public Playlist? GetPlaylistById(int id)
    {
        return _context.Playlists.FirstOrDefault(p => p.Id == id);
    }

    public List<Playlist> GetPlaylistsByUserId(int userId)
    {
        return _context.Playlists.Where(p => p.UserId == userId).ToList();
    }
    public bool UpdatePlaylist(Playlist playlist)
    {
        var existing = _context.Playlists.FirstOrDefault(p => p.Id == playlist.Id);
        if (existing is null) return false;
        existing.Name = playlist.Name;
        existing.Description = playlist.Description;
        existing.ImgSrc = playlist.ImgSrc;
        _context.SaveChanges();
        return true;
    }

    public bool DeletePlaylist(int id)
    {
        var playlist = _context.Playlists.FirstOrDefault(p => p.Id == id);
        if (playlist is null) return false;

        _context.Playlists.Remove(playlist);
        _context.SaveChanges();
        return true;
    }
    public void AddSongToPlaylist(int playlistId, int songId)
    {
        var playlist = _context.Playlists.FirstOrDefault(p => p.Id == playlistId);
        var existingSong = _context.Songs.FirstOrDefault(s => s.Id == songId);
        if (playlist is null || existingSong is null) return;
        playlist.Songs.Add(existingSong);
        _context.SaveChanges();
    }
    public void RemoveSongFromPlaylist(int playlistId, int songId)
    {
        var playlist = _context.Playlists.FirstOrDefault(p => p.Id == playlistId);
        var song = _context.Songs.FirstOrDefault(s => s.Id == songId);
        if (playlist is null || song is null) return;
        playlist.Songs.Remove(song);
        _context.SaveChanges();
    }

    public List<Song> GetSongsInPlaylist(int playlistId)
    {
        var playlist = _context.Playlists
            .Include(p => p.Songs)
            .FirstOrDefault(p => p.Id == playlistId);

        var songs = playlist?.Songs.ToList() ?? new List<Song>();
        return songs;
    }
    public List<Playlist> GetPlaylistsByName(string playlistName)
    {
        return _context.Playlists.Where(p => p.Name.Contains(playlistName)).ToList();
    }
}