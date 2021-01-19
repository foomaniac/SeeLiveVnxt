using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
