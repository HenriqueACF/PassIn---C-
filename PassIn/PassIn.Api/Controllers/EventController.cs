using Microsoft.AspNetCore.Mvc;
using PassIn.Communication.Requests;

namespace PassIn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]

public class EventController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestEventJson request)
    {
        return Created();
    }
}