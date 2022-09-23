namespace SeeLive.Domain.Features.Events
{
    public class GetEventCommandHandler : IRequestHandler<GetEventCommand,Event>
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly ILogger<GetEventCommandHandler> _logger;

        public GetEventCommandHandler(IEventsRepository eventsRepository, ILogger<GetEventCommandHandler> logger)
        {
            _eventsRepository = eventsRepository;
            _logger = logger;
        }

        public async Task<Event> Handle(GetEventCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call to get event with id {0}", request.EventId);
            return await _eventsRepository.GetAsync(request.EventId);
        }
    }
}
