using SeeLive.Core.Domain;
using SeeLive.Domain.AggregatesModel.VenueAggregate;
using SeeLive.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeLive.Domain.AggregatesModel.EventAggregate
{
    public class Event : Entity, IAggregateRoot
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
