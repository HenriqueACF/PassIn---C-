using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Attendees.GetAllByEventId;
using PassIn.Application.UseCases.Event.RegisterAttendee;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttendeesController : ControllerBase
{
    [HttpPost]
    [Route("{eventId}/register")]
    [ProducesResponseType(typeof(ResponseRegisterJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
    public IActionResult Register([FromRoute] Guid eventId, [FromBody] RequestRegisterEventJson request)
    {
        var useCase = new RegisterAttendeeOnEventUseCase();
        var response = useCase.Execute(eventId, request);
        
        return Created(String.Empty, response);
    }

    [HttpGet]
    [Route("{eventId}")]
    [ProducesResponseType(typeof(ResponseAllAttendeesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult getAll([FromRoute] Guid eventId)
    {
        var useCae = new GetAllAttendeeByEventIdUseCase();
        var response = useCae.Execute(eventId);
        
        return Ok(response);
    }
}