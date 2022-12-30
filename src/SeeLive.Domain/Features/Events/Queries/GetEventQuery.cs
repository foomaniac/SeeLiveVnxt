namespace SeeLive.Domain.Features.Events.Queries
{
    public class GetEventQuery : IRequest<Event>
    {
        public int EventId { get; set; }
    }
}
