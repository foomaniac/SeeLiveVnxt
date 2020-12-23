using MediatR;
using Microsoft.Extensions.Logging;
using SeeLive.Core.Domain.Entities;
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
        private SeeLiveContext _context;
        private ILogger<CreateArtistCommandHandler> _logger;

        public CreateArtistCommandHandler(SeeLiveContext context, ILogger<CreateArtistCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<bool> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Call to create artist with name {request.Name}");

            var artist = new Artist(request.Name, request.Bio, request.WebAddress);

            _context.Artists.Add(artist);

            var recordsCreated = await _context.SaveChangesAsync();

            _logger.LogInformation($"Records created {recordsCreated}");

            return recordsCreated > 0;
        }
    }
}
