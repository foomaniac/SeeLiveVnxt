using SeeLive.Domain.Seedwork;

namespace SeeLive.Domain.Models
{
    public class Artist : Entity
    {
        public Artist() { }
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
