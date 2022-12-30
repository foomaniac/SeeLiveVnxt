namespace SeeLive.Domain.Features.Events.Interfaces
{
    public interface IEventsRepository : IRepository<Event>
    {
        Event Add(Event newEvent);
        Task<Event> GetAsync(int eventId);
        void Update(Event existingEvent);
    }
}
