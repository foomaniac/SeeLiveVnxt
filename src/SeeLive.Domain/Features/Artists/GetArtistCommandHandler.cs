using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SeeLive.Domain.Entities;

namespace SeeLive.Domain.Features.Artists
{
    public class GetArtistCommandHandler : IRequestHandler<GetArtistCommand,Artist>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ILogger<GetArtistCommandHandler> _logger;

        public GetArtistCommandHandler(IArtistRepository artistRepository, ILogger<GetArtistCommandHandler> logger)
        {
            _artistRepository = artistRepository;
            _logger = logger;
        }

        public async Task<Artist> Handle(GetArtistCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call to get artist with id {0}", request.ArtistId);
            return await _artistRepository.GetAsync(request.ArtistId);
        }
    }
}
