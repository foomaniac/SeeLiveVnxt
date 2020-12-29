
using SeeLive.Domain.AggregatesModel.ArtistAggregate;
using System;

namespace SeeLive.Domain.AggregatesModel.EventAggregate
{
    public class EventListing : Entity
    {
        public EventListing() { }
        public EventListing(Artist artist, DateTime startTime, DateTime endTime)
        {
            Artist = artist;
            StartTime = startTime;
            EndTime = endTime;
        }
        public Artist Artist { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
    }
}
