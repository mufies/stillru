using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kita.Controllers;
[Authorize]
[ApiController]
[Route("/profile")]
public class ProfileController : ControllerBase
{
    
   [HttpGet]
public IActionResult GetProfile()
    {
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            return Ok("This is a protected profile endpoint.");
        }
        else
        {
            return Unauthorized("damn");
        }
    }}