using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Event.GetById;
using PassIn.Application.UseCases.Event.Register;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;

namespace PassIn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]

public class EventController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredEventJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestEventJson request)
    {
        try
        {
            var useCase = new RegisterEventUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (PassInException ex)
        {
            return BadRequest(new ResponseErrorJson(ex.Message));
        }
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        try
        {
            var useCase = new GetEventByIdUseCase();
            var response = useCase.Execute(id);

            return Ok(response);
        }
        catch (PassInException ex)
        {
            return NotFound(new ResponseErrorJson(ex.Message));
        }
    }
}
