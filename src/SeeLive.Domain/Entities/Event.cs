using System;
using System.Collections.Generic;

namespace SeeLive.Domain.Entities
{
    public class Event : Entity
    {
        public Event()
        {
            _eventListings = new List<EventListing>();
        }

        public Event(string name, string bio)
        {
            Name = name;
            Bio = bio;                        
        }

        public string Name { get; private set; }
        public string Bio { get; private set; }
        public DateTime EventDateTime { get; private set; }
        public Venue Venue { get; private set; }

        public void UpdateVenue(Venue venue)
        {
            Venue = venue;
        }

        public void UpdateEventDescription(string name, string bio)
        {
            Name = name;
            Bio = bio;
        }

        private readonly List<EventListing> _eventListings;
        public IReadOnlyCollection<EventListing> EventLists => _eventListings;
    }
}
