using SeeLive.Domain.AggregatesModel.ArtistAggregate;
using SeeLive.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeeLive.Domain.AggregatesModel.ArtistAggregate
{
   public interface IArtistRepository : IRepository<Artist>
    {
        Artist Add(Artist artist);
        void Update(Artist artist);

        Task<Artist> GetAsync(int artistId);
    }
}
