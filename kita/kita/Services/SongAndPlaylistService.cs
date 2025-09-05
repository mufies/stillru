namespace kita.Services;

public class SongAndPlaylistService
{
    private readonly ISongRepository _SongRepository;
    private readonly IPlaylistRepository _PlaylistRepository;

    public SongAndPlaylistService(ISongRepository songRepository, IPlaylistRepository playlistRepository)
    {
        _SongRepository = songRepository;
        _PlaylistRepository = playlistRepository;
    }
    
    public Song? GetSongById(int id)
    {
        return _SongRepository.GetSongById(id);
    }
    public Song CreateSong(Song song)
    {
        return _SongRepository.CreateSong(song);
    }

    public void UpdateSong(Song song)
    {
        _SongRepository.UpdateSong(song);
    }
    public void DeleteSong(int id)
    {
        _SongRepository.DeleteSong(id);
    }
    public List<Song> GetSongsByArtist(string artist)
    {
        return _SongRepository.GetSongsByArtist(artist);
    }

    public List<Song> GetSongsByAlbum(string album)
    {
        return _SongRepository.GetSongsByAlbum(album);
    }
    public List<Song> GetSongsByGenre(string genre)
    {
        return _SongRepository.GetSongsByGenre(genre);
    }

    public List<Song> GetSongsByTitle(string title)
    {
        return _SongRepository.GetSongsByTitle(title);
    }
    
    public List<Song> GetTopNSongs(int n)
    {
        return _SongRepository.GetTopNSongs(n);
    }

    public Playlist CreatePlaylist(Playlist playlist)
    {
        return _PlaylistRepository.CreatePlaylist(playlist);
    }
    public Playlist? GetPlaylistById(int id)
    {
        return _PlaylistRepository.GetPlaylistById(id);
    }

    public List<Playlist> GetPlaylistsByUserId(int userId)
    {
        return _PlaylistRepository.GetPlaylistsByUserId(userId);
    }
    public void UpdatePlaylist(Playlist playlist)
    {
        _PlaylistRepository.UpdatePlaylist(playlist);
    }

    public void DeletePlaylist(int id)
    {
        _PlaylistRepository.DeletePlaylist(id);
    }
    public void AddSongToPlaylist(int playlistId, int songId)
    {
        _PlaylistRepository.AddSongToPlaylist(playlistId, songId);
    }

    public void RemoveSongFromPlaylist(int playlistId, int songId)
    {
        _PlaylistRepository.RemoveSongFromPlaylist(playlistId, songId);
    }
    public List<Song> GetSongsInPlaylist(int playlistId)
    {
        return _PlaylistRepository.GetSongsInPlaylist(playlistId);
    }

    public List<Playlist> GetPlaylistsByName(string playlistName)
    {
        return _PlaylistRepository.GetPlaylistsByName(playlistName);
    }
}