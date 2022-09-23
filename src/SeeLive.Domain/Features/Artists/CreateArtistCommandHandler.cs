using System.Threading.Tasks;

namespace SeeLive.Domain.Features.Artists
{
    public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, Artist>
    {
        private readonly IArtistsRepository _artistRepository;
        private readonly ILogger<CreateArtistCommandHandler> _logger;

        public CreateArtistCommandHandler(IArtistsRepository artistRepository, ILogger<CreateArtistCommandHandler> logger)
        {
            _artistRepository = artistRepository;
            _logger = logger;
        }


        public async Task<Artist> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Call to create artist with name {0}", request.Name);

            Artist artist = new Artist(request.Name, request.Bio, request.WebAddress);

            _artistRepository.Add(artist);

            await _artistRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return artist;
        }
    }
}
