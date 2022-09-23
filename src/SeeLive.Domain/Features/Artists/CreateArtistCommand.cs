using SeeLive.Domain.Entities;

namespace SeeLive.Domain.Features.Artists
{
    public class CreateArtistCommand : IRequest<Artist>
    {
        public string Name { get; private set; }
        public string Bio { get; private set; }
        public string WebAddress { get; private set; }

        public CreateArtistCommand(string name, string bio, string webAddress)
        {
            Name = name;
            Bio = bio;
            WebAddress = webAddress;
        }
    }
}
