using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeeLive.Domain.Entities;

namespace SeeLive.Domain.Features.Artists
{
    public class GetArtistCommand : IRequest<Artist>
    {
        public int ArtistId { get; set; }
    }
}
