using System.Net.Mail;
using PassIn.Communication.Requests;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Event.RegisterAttendee;

public class RegisterAttendeeOnEventUseCase
{
    public void Execute(Guid eventId, RequestRegisterEventJson request)
    {
        var dbContext = new PassInDbContext();
    }

    private void Validate(Guid eventId, RequestRegisterEventJson request, PassInDbContext dbContext)
    {
        var existEvent = dbContext.Events.Any(ev => ev.Id == eventId);
        if (existEvent == false)
        {
            throw new NotFoundException("An Event with this id was not found");
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ErrorOnValidationException("the name is invalid");
        }

        if (EmailIsValid(request.Email) == false)
        {
            throw new ErrorOnValidationException("the E-mail is invalid");
        }

        var attendeeAlreadyRegistered = dbContext.Attendees.Any(attendee => attendee.Email.Equals(request.Email));

    }

    private bool EmailIsValid(string email)
    {
        try
        {
            //valida se o email esta em um formato correto
            new MailAddress(email);
        
            return true;
        }
        catch
        {
            return false;
        }
    }
    
}