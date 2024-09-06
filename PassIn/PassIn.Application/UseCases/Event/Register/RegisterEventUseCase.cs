using PassIn.Communication.Requests;
using PassIn.Exceptions;

namespace PassIn.Application.UseCases.Event.Register;

public class RegisterEventUseCase
{
    public void Execute(RequestEventJson request)
    {
        Validate(request);
    }
    
    private void Validate(RequestEventJson request)
    {
        if(request.MaximumAttendees <= 0)
        {
            throw new PassInException("The maximum attendees is invalid.");
        }
        
        if(string.IsNullOrWhiteSpace(request.Title))
        {
            throw new PassInException("the title is invalid.");
        }
        
        if(string.IsNullOrWhiteSpace(request.Details))
        {
            throw new PassInException("the details is invalid.");
        }
    }
}