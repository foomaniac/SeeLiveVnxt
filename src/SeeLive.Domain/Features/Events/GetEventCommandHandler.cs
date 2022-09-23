using Microsoft.Extensions.Logging;
using SeeLive.Domain.Entities;
using SeeLive.Domain.Features.Events;

namespace SeeLive.Domain.Features.Artists
{
    public class GetEventCommandHandler : IRequestHandler<GetEventCommand,Event>
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly ILogger<GetArtistCommandHandler> _logger;

        public GetEventCommandHandler(IEventsRepository eventsRepository, ILogger<GetArtistCommandHandler> logger)
        {
            _eventsRepository = eventsRepository;
            _logger = logger;
        }

        public async Task<Event> Handle(GetEventCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call to get artist with id {0}", request.EventId);
            return await _eventsRepository.GetAsync(request.EventId);
        }
    }
}
