// ...existing code...
[HttpPost]
public IActionResult CreatePlaylist([FromBody] Playlist playlist)
{
    var createdPlaylist = _playlistRepository.CreatePlaylist(playlist);
    return CreatedAtAction(nameof(GetPlaylists), new { id = createdPlaylist.Id }, createdPlaylist);
}
// ...existing code...

