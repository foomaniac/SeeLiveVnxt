using SeeLive.Domain.Features.Events.Commands;
using SeeLive.Domain.Features.Events.Interfaces;

namespace SeeLive.Domain.Features.Events.Handlers
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
            _logger.LogInformation("Call to create event with name {0}", request.Name);

            Event newEvent = new Event(request.Name, request.Bio);

            _eventsRepository.Add(newEvent);

            await _eventsRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return newEvent;
        }
    }
}
