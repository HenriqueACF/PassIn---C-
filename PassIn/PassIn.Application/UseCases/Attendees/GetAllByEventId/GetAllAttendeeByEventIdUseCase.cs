using PassIn.Communication.Responses;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Attendees.GetAllByEventId;

public class GetAllAttendeeByEventIdUseCase
{
    private readonly PassInDbContext _dbContext;
    public GetAllAttendeeByEventIdUseCase()
    {
        _dbContext = new PassInDbContext();
    }
    public ResponseAllAttendeesJson Execute(Guid eventId)
    {
        
    }
}