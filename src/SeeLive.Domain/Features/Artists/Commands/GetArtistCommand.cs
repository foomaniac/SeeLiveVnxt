using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeLive.Domain.Features.Artists.Commands
{
    public class GetArtistCommand : IRequest<Artist>
    {
        public int ArtistId { get; set; }
    }
}
