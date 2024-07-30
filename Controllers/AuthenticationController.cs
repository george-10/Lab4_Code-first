using Lab4_Part2.Models;
using Lab4_Part2.Services.Absractions;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Part2.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController(IKeycloakService keycloakService) : ControllerBase
{
 

    [HttpPost]
    public async Task<IActionResult> login([FromBody] LoginDto request)
    {
       var res = await keycloakService.Login(request.Username,request.Password);
       return Ok(res);
    }

}