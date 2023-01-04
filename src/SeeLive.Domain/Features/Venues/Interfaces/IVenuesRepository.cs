using SeeLive.Domain.Features.Venues;

namespace SeeLive.Domain.Features.Events.Interfaces
{
    public interface IVenuesRepository : IRepository<Venue>
    {
        Venue Add(Venue newVenue);
        Task<Venue> GetAsync(int venueId);
        void Update(Venue existingVenue);
    }
}
