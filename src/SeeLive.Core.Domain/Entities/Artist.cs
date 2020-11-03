using System;
using System.Collections.Generic;

namespace SeeLive.Core.Domain.Entities
{
    public class Artist : IEntity<int>
    {
        public int Id { get; set; }
        public string Name {get; set;}

        public string Bio {get; set;}

        public string City {get; set;}

        public string WebAddress {get; set;}
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateArchived { get; set; }
        public string CreatedByUser { get; set; }

        public IEnumerable<EventListing> EventListings { get; set; }
    }
}
