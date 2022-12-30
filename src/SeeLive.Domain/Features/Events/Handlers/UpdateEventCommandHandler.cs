using System;
using SeeLive.Domain.Features.Events.Commands;
using SeeLive.Domain.Features.Events.Interfaces;
using SeeLive.Domain.Features.Venues;

namespace SeeLive.Domain.Features.Events.Handlers
{

    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Event>
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly IVenuesRepository _venuesRepository;
        private readonly ILogger<UpdateEventCommandHandler> _logger;

        public UpdateEventCommandHandler(IEventsRepository eventsRepository, IVenuesRepository venuesRepository, ILogger<UpdateEventCommandHandler> logger)
        {
            _eventsRepository = eventsRepository;
            _venuesRepository = venuesRepository;
            _logger = logger;            
        }


        public async Task<Event> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call to update event with id {0}", request.EventId);

            Event existingEvent = await _eventsRepository.GetAsync(request.EventId);

            if (existingEvent == null)
            {
                throw new ArgumentException($"No event found for given id {request.EventId}", nameof(request.EventId));
            }

            existingEvent.UpdateBio(request.Bio);
            existingEvent.UpdateName(request.Name);

            if (request.VenueId.HasValue && request.VenueId.Value != existingEvent.Venue.Id)
            {
                Venue updatedVenue = await _venuesRepository.GetAsync(request.VenueId.Value);
                if(updatedVenue == null)
                {
                    throw new ArgumentException($"No venue found for given id {request.VenueId}", nameof(request.VenueId));
                }
            }

            _eventsRepository.Update(existingEvent);

            await _eventsRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            Event updatedEvent = await _eventsRepository.GetAsync(request.EventId);

            return existingEvent;
        }
    }
}
