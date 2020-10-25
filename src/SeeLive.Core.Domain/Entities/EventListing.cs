using System;
using System.Collections.Generic;
using System.Text;

namespace SeeLive.Core.Domain.Entities
{
    public class EventListing : IEntity<int>
    {
        public int Id {get; set;}

        public int EventId { get; set; }
        public int ArtistId { get; set; }

        public int VenueId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime DateCreated {get; set;}
        public DateTime? DateModified {get; set;}
        public DateTime? DateDeleted {get; set;}
        public string CreatedByUser {get; set;}
    }
}
