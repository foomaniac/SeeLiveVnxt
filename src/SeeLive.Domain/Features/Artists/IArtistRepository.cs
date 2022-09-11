using SeeLive.Domain.Models;
using SeeLive.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeeLive.Domain.Features.Artists
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Artist Add(Artist artist);
        void Update(Artist artist);

        Task<Artist> GetAsync(int artistId);
    }
}
