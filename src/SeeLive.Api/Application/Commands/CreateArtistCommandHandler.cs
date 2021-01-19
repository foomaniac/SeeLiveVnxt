using MediatR;
using Microsoft.Extensions.Logging;
using SeeLive.Domain.AggregatesModel.ArtistAggregate;
using SeeLive.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SeeLive.Api.Application.Commands
{
    public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, bool>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ILogger<CreateArtistCommandHandler> _logger;

        public CreateArtistCommandHandler(IArtistRepository artistRepository, ILogger<CreateArtistCommandHandler> logger)
        {
            _artistRepository = artistRepository;
            _logger = logger;
        }


        public async Task<bool> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Call to create artist with name {request.Name}");

            var artist = new Artist(request.Name, request.Bio, request.WebAddress);

            _artistRepository.Add(artist);
                       
            return await _artistRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
