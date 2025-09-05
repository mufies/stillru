using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kita.Controllers;

[Authorize]
[ApiController]
[Route("/song")]
public class SongController : ControllerBase
{
    private readonly SongAndPlaylistService _songAndPlaylistService;
    public SongController(SongAndPlaylistService songAndPlaylistService)
    {
        _songAndPlaylistService = songAndPlaylistService;
    }
    
    public int GetUserId()
    {
        var userIdClaim = User.FindFirst("id")?.Value;
        if (string.IsNullOrEmpty(userIdClaim)) throw new UnauthorizedAccessException();
        return int.Parse(userIdClaim);
    }

    [HttpPost]
    public IActionResult AddSong(Song song)
    {
        if (song == null || string.IsNullOrEmpty(song.Title) || string.IsNullOrEmpty(song.Artist))
        {
            return BadRequest("Invalid song data.");
        }

        int userId = GetUserId();
        song.UserId = userId;

        var addedSong = _songAndPlaylistService.CreateSong(song);
        return CreatedAtAction(nameof(AddSong), new { id = addedSong.Id }, addedSong);
    }

    [HttpGet("{id}")]
    public IActionResult GetSongById(int id)
    {
        var song = _songAndPlaylistService.GetSongById(id);
        if (song == null)
            return NotFound();
        return Ok(song);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteSong(int id)
    {
        int userId = GetUserId();
        var song = _songAndPlaylistService.GetSongById(id);
        if (song == null || song.UserId != userId)
            return NotFound();

        _songAndPlaylistService.DeleteSong(id);
        return Ok("Song deleted successfully.");
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateSong(int id, Song updatedSong)
    {
        if (updatedSong == null || string.IsNullOrEmpty(updatedSong.Title) || string.IsNullOrEmpty(updatedSong.Artist))
        {
            return BadRequest("Invalid song data.");
        }

        int userId = GetUserId();
        var existingSong = _songAndPlaylistService.GetSongById(id);
        if (existingSong == null || existingSong.UserId != userId)
            return NotFound();

        updatedSong.Id = id;
        updatedSong.UserId = userId;
        _songAndPlaylistService.UpdateSong(updatedSong);
        return Ok("Song updated successfully.");
    }
    
    [HttpPost("add-to-playlist/{playlistId}/song/{songId}")]
    public IActionResult AddSongToPlaylist(int playlistId, int songId)
    {
        int userId = GetUserId();
        var playlist = _songAndPlaylistService.GetPlaylistById(playlistId);
        var song = _songAndPlaylistService.GetSongById(songId);
        if (playlist == null || playlist.UserId != userId || song == null || song.UserId != userId)
            return NotFound("Playlist or Song not found.");

        _songAndPlaylistService.AddSongToPlaylist(playlistId, songId);
        return Ok("Song added to playlist successfully.");
    }
    
    
}