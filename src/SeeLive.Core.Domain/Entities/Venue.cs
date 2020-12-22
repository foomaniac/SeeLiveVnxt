using System;
using System.Collections.Generic;
using System.Text;

namespace SeeLive.Core.Domain.Entities
{
    public class Venue : IEntity<int>, IAddressEntity
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime DateCreated {get; set;}
        public DateTime? DateModified {get; set;}
        public DateTime? DateArchived {get; set;}
        public string CreatedByUser {get; set;}
        public string AddressLine1 {get; set;}
        public string AddressLine2 {get; set;}
        public string AddressLine3 {get; set;}
        public string PostCode {get; set;}
        public string City {get; set;}
        public string County {get; set;}
        public string Country {get; set;}

        public IEnumerable<EventListing> EventListings { get; set; }
    }
}
