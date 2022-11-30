﻿using System.Threading.Tasks;

namespace SeeLive.Domain.Features.Events
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Event>
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly ILogger<CreateEventCommandHandler> _logger;

        public CreateEventCommandHandler(IEventsRepository eventsRepository, ILogger<CreateEventCommandHandler> logger)
        {
            _eventsRepository = eventsRepository;
            _logger = logger;
        }


        public async Task<Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call to create artist with name {0}", request.Name);

            Venue venue = new Venue();
             
            Event newEvent = new Event(request.Name, request.Bio, venue);

            _eventsRepository.Add(newEvent);

            await _eventsRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return newEvent;
        }
    }
}
