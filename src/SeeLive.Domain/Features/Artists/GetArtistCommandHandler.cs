using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using SeeLive.Domain.Models;

namespace SeeLive.Domain.Features.Artists
{
    public class GetArtistCommandHandler : IRequestHandler<GetArtistCommand,Artist>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ILogger<CreateArtistCommandHandler> _logger;

        public GetArtistCommandHandler(IArtistRepository artistRepository, ILogger<CreateArtistCommandHandler> logger)
        {
            _artistRepository = artistRepository;
            _logger = logger;
        }

        public async Task<Artist> Handle(GetArtistCommand request, CancellationToken cancellationToken)
        {
            return await _artistRepository.GetAsync(request.ArtistId);
        }
    }
}
