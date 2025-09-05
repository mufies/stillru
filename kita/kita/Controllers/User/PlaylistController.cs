using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace kita.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize] // yêu cầu đăng nhập
public class PlaylistsController : ControllerBase
{
    private readonly SongAndPlaylistService _songAndPlaylistService;
    
    public PlaylistsController(SongAndPlaylistService songAndPlaylistService)
    {
        _songAndPlaylistService = songAndPlaylistService;
    }

    // Lấy userId từ token (claim "sub" hoặc "id")
    private int GetUserId()
    {
        var userIdClaim = User.FindFirst("id")?.Value;
        if (string.IsNullOrEmpty(userIdClaim)) throw new UnauthorizedAccessException();
        return int.Parse(userIdClaim);
    }

    [HttpGet]
    public IActionResult GetMyPlaylists()
    {
        int userId = GetUserId();
        var playlists = _songAndPlaylistService.GetPlaylistsByUserId(userId);
        return Ok(playlists);
    }

    [HttpPost]
    public IActionResult CreatePlaylist([FromBody] Playlist playlist)
    {
        int userId = GetUserId();
        playlist.UserId = userId;

        var createdPlaylist = _songAndPlaylistService.CreatePlaylist(playlist);
        return CreatedAtAction(nameof(GetPlaylistById), new { id = createdPlaylist.Id }, createdPlaylist);
    }

    [HttpGet("{id}")]
    public IActionResult GetPlaylistById(int id)
    {
        int userId = GetUserId();
        var playlist = _songAndPlaylistService.GetPlaylistById(id);

        if (playlist == null || playlist.UserId != userId)
            return NotFound();

        var songs = _songAndPlaylistService.GetSongsInPlaylist(id);
        return Ok(new { playlist, songs });
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePlaylist(int id)
    {
        int userId = GetUserId();
        var playlist = _songAndPlaylistService.GetPlaylistById(id);

        if (playlist == null || playlist.UserId != userId)
            return NotFound();

        _songAndPlaylistService.DeletePlaylist(id);
        return NoContent();
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdatePlaylist(int id, [FromBody] Playlist updatedPlaylist)
    {
        int userId = GetUserId();
        var existingPlaylist = _songAndPlaylistService.GetPlaylistById(id);

        if (existingPlaylist == null || existingPlaylist.UserId != userId)
            return NotFound();

        existingPlaylist.Name = updatedPlaylist.Name;
        existingPlaylist.Description = updatedPlaylist.Description;
        existingPlaylist.ImgSrc = updatedPlaylist.ImgSrc;

        _songAndPlaylistService.UpdatePlaylist(existingPlaylist);
        return NoContent();
    }
    
    // [HttpPut("{playlistId}/songs")]
    // public IActionResult AddSongToPlaylist(int playlistId, [FromBody] int song)
    // {
    //     int userId = GetUserId();
    //     var playlist = _songAndPlaylistService.GetPlaylistById(playlistId);
    //
    //     if (playlist == null || playlist.UserId != userId)
    //         return NotFound();
    //
    //     _songAndPlaylistService.AddSongToPlaylist(playlistId, song);
    //     return NoContent();
    // }
    
}
