﻿ using System;
using System.Collections.Generic;
using System.Text;

namespace SeeLive.Core.Domain.Entities
{
    public class Event : Entity
    {
        public Event(string name, string bio, Venue venue)
        {
            Name = name;
            Bio = bio;
            Venue = venue;
        }
        
        public string Name {get; private set;}
        public string Bio {get; private set;}
        public Venue Venue {get; private set;}
        private readonly List<EventListing> _eventListings;
        public IReadOnlyCollection<EventListing> EventLists => _eventListings;
    }
}
