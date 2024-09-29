using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.CheckIns.DoCheckin;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CheckInController: ControllerBase
{
    [HttpPost]
    [Route("{attendeeId}")]
    [ProducesResponseType(typeof(ResponseRegisterJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
    public IActionResult Checkin([FromRoute] Guid attendeeId)
    {
        var useCase = new DoAttendeeCheckInUseCase();
        var response = useCase.Execute(attendeeId);
        
        return Created(string.Empty, response);
    }
}