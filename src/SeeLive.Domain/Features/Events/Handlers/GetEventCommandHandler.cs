using SeeLive.Domain.Features.Events.Interfaces;
using SeeLive.Domain.Features.Events.Queries;

namespace SeeLive.Domain.Features.Events.Handlers
{
    public class GetEventCommandHandler : IRequestHandler<GetEventQuery, Event>
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly ILogger<GetEventCommandHandler> _logger;

        public GetEventCommandHandler(IEventsRepository eventsRepository, ILogger<GetEventCommandHandler> logger)
        {
            _eventsRepository = eventsRepository;
            _logger = logger;
        }

        public async Task<Event> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call to get event with id {0}", request.EventId);
            return await _eventsRepository.GetAsync(request.EventId);
        }
    }
}
