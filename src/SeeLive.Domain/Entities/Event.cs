using System.Collections.Generic;

namespace SeeLive.Domain.Entities
{
    public class Event : Entity
    {
        public Event()
        {
            _eventListings = new List<EventListing>();
        }

        public Event(string name, string bio, Venue venue)
        {
            Name = name;
            Bio = bio;
            Venue = venue;
            //TODO: Load existing listings
            _eventListings = new List<EventListing>();
        }

        public string Name { get; private set; }
        public string Bio { get; private set; }
        public Venue Venue { get; private set; }

        private readonly List<EventListing> _eventListings;
        public IReadOnlyCollection<EventListing> EventLists => _eventListings;
    }
}
