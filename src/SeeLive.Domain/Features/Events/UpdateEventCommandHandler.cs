using System;

namespace SeeLive.Domain.Features.Events
{

    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Event>
    {
        private readonly IEventsRepository _eventsRepository;        
        private readonly ILogger<UpdateEventCommandHandler> _logger;

        public UpdateEventCommandHandler(IEventsRepository eventsRepository, ILogger<UpdateEventCommandHandler> logger)
        {
            _eventsRepository = eventsRepository;
            _logger = logger;
        }


        public async Task<Event> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call to update event with id {0}", request.EventId);

            Event existingEvent =  await _eventsRepository.GetAsync(request.EventId);

            if(existingEvent == null)
            {
                throw new ArgumentException("No event found for given id",nameof(request.EventId));            
            }

            existingEvent.UpdateEventDescription(request.Name, request.Bio);

            if (request.VenueId.HasValue)
            {
                throw new NotImplementedException("Update venue not implemented");
            }
            
            _eventsRepository.Update(existingEvent);

            await _eventsRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            Event updatedEvent = await _eventsRepository.GetAsync(request.EventId);

            return existingEvent;
        }
    }
}
