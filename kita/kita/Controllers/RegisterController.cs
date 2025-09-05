using Microsoft.AspNetCore.Mvc;

namespace kita.Controllers;

[ApiController]
[Route("/register")]
public class RegisterController : ControllerBase
{
    private readonly UserService _userService;
    
    public RegisterController(UserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    public IActionResult AddUser(User user)
    {
        if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password) )
        {
            return BadRequest("Invalid user data.");
        }

        var isAdded = _userService.addUser(user);
        if (!isAdded)
        {
            return Conflict("User with the same email already exists.");
        }

        return CreatedAtAction(nameof(AddUser), new { id = user.Id }, user);
    }
}