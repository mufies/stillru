// ...existing code...
    // Playlist management
    public Playlist CreatePlaylist(Playlist playlist)
    {
        return _PlaylistRepository.CreatePlaylist(playlist);
    }
    public void UpdatePlaylist(Playlist playlist)
    {
        _PlaylistRepository.UpdatePlaylist(playlist);
    }
    public void DeletePlaylist(int id)
    {
        _PlaylistRepository.DeletePlaylist(id);
    }
    public List<Playlist> GetPlaylistsByUser(int userId)
    {
        return _PlaylistRepository.GetPlaylistsByUser(userId);
    }
    public void AddSongToPlaylist(int playlistId, int songId)
    {
        _PlaylistRepository.AddSongToPlaylist(playlistId, songId);
    }
    public void RemoveSongFromPlaylist(int playlistId, int songId)
    {
        _PlaylistRepository.RemoveSongFromPlaylist(playlistId, songId);
    }

    // Song search
    public List<Song> SearchSongsByTitle(string title)
    {
        return _SongRepository.SearchSongsByTitle(title);
    }

    // User favorites
    public void AddSongToFavorites(int userId, int songId)
    {
        _SongRepository.AddSongToFavorites(userId, songId);
    }
    public void RemoveSongFromFavorites(int userId, int songId)
    {
        _SongRepository.RemoveSongFromFavorites(userId, songId);
    }
    public List<Song> GetFavoriteSongs(int userId)
    {
        return _SongRepository.GetFavoriteSongs(userId);
    }
    public void AddPlaylistToFavorites(int userId, int playlistId)
    {
        _PlaylistRepository.AddPlaylistToFavorites(userId, playlistId);
    }
    public void RemovePlaylistFromFavorites(int userId, int playlistId)
    {
        _PlaylistRepository.RemovePlaylistFromFavorites(userId, playlistId);
    }
    public List<Playlist> GetFavoritePlaylists(int userId)
    {
        return _PlaylistRepository.GetFavoritePlaylists(userId);
    }

    // Recently played songs
    public void AddRecentlyPlayedSong(int userId, int songId)
    {
        _SongRepository.AddRecentlyPlayedSong(userId, songId);
    }
    public List<Song> GetRecentlyPlayedSongs(int userId)
    {
        return _SongRepository.GetRecentlyPlayedSongs(userId);
    }

    // Top charts
    public List<Song> GetTopSongs(int count)
    {
        return _SongRepository.GetTopSongs(count);
    }

    // Recommendations
    public List<Song> GetRecommendedSongs(int userId)
    {
        return _SongRepository.GetRecommendedSongs(userId);
    }

    // Playlist sharing
    public string GetShareablePlaylistLink(int playlistId)
    {
        return _PlaylistRepository.GetShareablePlaylistLink(playlistId);
    }

    // Song/playlist comments or ratings
    public void AddSongComment(int songId, int userId, string comment)
    {
        _SongRepository.AddSongComment(songId, userId, comment);
    }
    public List<string> GetSongComments(int songId)
    {
        return _SongRepository.GetSongComments(songId);
    }
    public void AddPlaylistComment(int playlistId, int userId, string comment)
    {
        _PlaylistRepository.AddPlaylistComment(playlistId, userId, comment);
    }
    public List<string> GetPlaylistComments(int playlistId)
    {
        return _PlaylistRepository.GetPlaylistComments(playlistId);
    }
// ...existing code...

