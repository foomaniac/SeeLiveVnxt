namespace SeeLive.Domain.Features.Events
{
    public interface IEventsRepository : IRepository<Event>
    {
        Event Add(Event newEvent);
        Task<Event> GetAsync(int eventId);
        void Update(Event existingEvent);
    }
}
