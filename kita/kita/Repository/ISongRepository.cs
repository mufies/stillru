namespace kita.Repository;

public interface ISongRepository
{
    public Song CreateSong(Song song);
    public Song? GetSongById(int id);
        // public List<Song> GetAllSongs();
    public bool UpdateSong(Song song);
    public bool DeleteSong(int id);
    public List<Song> GetSongsByArtist(string artist);
    public List<Song> GetSongsByAlbum(string album);
    public List<Song> GetSongsByGenre(string genre);
    public List<Song> GetSongsByTitle(string title);
    public List<Song> GetTopNSongs(int n);
}