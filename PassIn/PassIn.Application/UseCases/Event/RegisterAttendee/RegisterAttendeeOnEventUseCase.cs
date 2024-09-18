using System.Net.Mail;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Event.RegisterAttendee;

public class RegisterAttendeeOnEventUseCase
{
    private readonly PassInDbContext _dbContext;
    
    public RegisterAttendeeOnEventUseCase()
    {
        _dbContext = new PassInDbContext();
    }
    
    public ResponseRegisterJson Execute(Guid eventId, RequestRegisterEventJson request)
    {
        Validate(eventId, request);

        var entity = new Infrastructure.Entities.Attendee()
        {
            Email = request.Email,
            Name = request.Name,
            Event_Id = eventId,
            Create_At = DateTime.UtcNow
        };

        _dbContext.Attendees.Add(entity);
        _dbContext.SaveChanges();

        return new ResponseRegisterJson()
        {
            Id = entity.Id
        };
    }

    private void Validate(Guid eventId, RequestRegisterEventJson request)
    {
        var existEvent = _dbContext.Events.Any(ev => ev.Id == eventId);
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

        var attendeeAlreadyRegistered = _dbContext.Attendees.Any(attendee => attendee.Email.Equals(request.Email));

        if (attendeeAlreadyRegistered)
        {
            throw new ErrorOnValidationException("You can not register twice on the same event");
        }

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