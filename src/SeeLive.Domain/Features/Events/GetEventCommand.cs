using SeeLive.Domain.Entities;

namespace SeeLive.Domain.Features.Events
{
    public class GetEventCommand : IRequest<Event>
    {
        public int EventId { get; set; }
    }
}
