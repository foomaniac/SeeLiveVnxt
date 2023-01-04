using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using SeeLive.Domain;
using SeeLive.Domain.Features.Events.Interfaces;
using SeeLive.Domain.Features.Events;

namespace SeeLive.Infrastructure.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly SeeLiveContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public EventsRepository(SeeLiveContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Event Add(Event newEvent)
        {
            return _context.Events.Add(newEvent).Entity;
        }

        public async Task<Event> GetAsync(int eventId)
        {
            var existingEvent = await _context.Events.FirstOrDefaultAsync(o => o.Id == eventId);

            return existingEvent;
        }

        public void Update(Event existingEvent)
        {
            _context.Entry(existingEvent).State = EntityState.Modified;
        }
    }
}
