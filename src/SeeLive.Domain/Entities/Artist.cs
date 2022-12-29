using Microsoft.EntityFrameworkCore;

namespace SeeLive.Domain.Entities
{    
    public sealed class Artist : Entity
    {
        public Artist() { }
        public Artist(int id, string name, string bio, string webAddress)
        {
            Id = id;
            Name = name;
            Bio = bio;
            WebAddress = webAddress;
        }

        public Artist(string name, string bio, string webAddress)
        {
            Name = name;
            Bio = bio;
            WebAddress = webAddress;
        }
        public string Name { get; private set; }
        public string Bio { get; private set; }
        public string WebAddress { get; private set; }
    }
}
