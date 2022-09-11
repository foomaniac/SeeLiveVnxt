using Microsoft.EntityFrameworkCore;
using SeeLive.Domain.Features.Artists;
using SeeLive.Domain.Models;
using SeeLive.Domain.Seedwork;
using System;
using System.Threading.Tasks;

namespace SeeLive.Infrastructure.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly SeeLiveContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

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
