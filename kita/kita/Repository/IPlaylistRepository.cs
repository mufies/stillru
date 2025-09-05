namespace kita.Repository;

public interface IPlaylistRepository
{
    public Playlist CreatePlaylist(Playlist playlist);
    public Playlist? GetPlaylistById(int id);
    public List<Playlist> GetPlaylistsByUserId(int userId);
    public bool UpdatePlaylist(Playlist playlist);
    public bool DeletePlaylist(int id);
    public void AddSongToPlaylist(int playlistId, int songId);
    public void RemoveSongFromPlaylist(int playlistId, int songId);
    public List<Song> GetSongsInPlaylist(int playlistId);
    public List<Playlist> GetPlaylistsByName(string playlistName);
    
}