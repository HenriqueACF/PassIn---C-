using PassIn.Communication.Requests;

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
            throw new ArgumentException("The maximum attendees is invalid.");
        }
        
        if(string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("the title is invalid.");
        }
        
        if(string.IsNullOrWhiteSpace(request.Details))
        {
            throw new ArgumentException("the details is invalid.");
        }
    }
}