using kita.Controllers.Infastructure;
using kita.Model;
using kita.Repository;
using kita.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace kita.Controllers;

[ApiController]
[Route("/login")]
public class LoginController : ControllerBase
{
    
    private readonly UserService _userService;
    private readonly TokenProvider _tokenProvider;

    public LoginController(UserService userService, TokenProvider tokenProvider)
    {
        _userService = userService;
        _tokenProvider = tokenProvider;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {

        User? user = _userService.isAccountValid(loginRequest.Email, loginRequest.Password);
        if (user == null)
        {
            return Unauthorized("Invalid username or password.");
        }
        else
        {
                var token = _tokenProvider.Create(user);
                return Ok(new { Token = token });
                

        }
    }






}