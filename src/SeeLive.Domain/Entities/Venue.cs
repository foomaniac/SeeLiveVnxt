namespace SeeLive.Domain.Entities
{
    public class Venue : Entity
    {
        public Venue() { }

        public Venue(string name, string bio, Address address)
        {
            Name = name;
            Bio = bio;
            Address = address;
        }
        public string Name { get; private set; }
        public string Bio { get; private set; }
        public Address Address { get; private set; }
    }
}
