using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using SeeLive.Domain;
using SeeLive.Domain.Features.Events.Interfaces;
using SeeLive.Domain.Features.Events;
using SeeLive.Domain.Features.Venues;

namespace SeeLive.Infrastructure.Repositories
{
    public class VenuesRepository : IVenuesRepository
    {
        private readonly SeeLiveContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public VenuesRepository(SeeLiveContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Venue Add(Venue newVenue)
        {
            return _context.Venues.Add(newVenue).Entity;
        }

        public async Task<Venue> GetAsync(int venueId)
        {
            var existingVenue = await _context.Venues.FirstOrDefaultAsync(o => o.Id == venueId);

            return existingVenue;
        }

        public void Update(Venue existingVenue)
        {
            _context.Entry(existingVenue).State = EntityState.Modified;
        }
    }
}
