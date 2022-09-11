using MediatR;

namespace SeeLive.Api.Application.Commands
{
    public class CreateArtistCommand : IRequest<bool>
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
