using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using SeeLive.Domain;
using SeeLive.Domain.Features.Artists.Interfaces;

namespace SeeLive.Infrastructure.Repositories
{
    public class ArtistRepository : IArtistsRepository
    {
        private readonly SeeLiveContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ArtistRepository(SeeLiveContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Artist Add(Artist artist)
        {
            return _context.Artists.Add(artist).Entity;
        }

        public async Task<Artist> GetAsync(int artistId)
        {
            var artist = await _context.Artists.FirstOrDefaultAsync(o => o.Id == artistId);

            return artist;
        }

        public void Update(Artist artist)
        {
            _context.Entry(artist).State = EntityState.Modified;
        }
    }
}
