
using System.Collections.Generic;
using SeeLive.Domain.Seedwork;

namespace SeeLive.Domain.Models
{
    public class Address : ValueObject
    {
        public string AddressLine1 { get; private set; }
        public string PostCode { get; private set; }
        public string City { get; private set; }
        public string County { get; private set; }
        public string Country { get; private set; }

        public Address() { }

        public Address(string addressLine1, string postcode, string city, string county, string country)
        {
            AddressLine1 = addressLine1;
            PostCode = postcode;
            City = city;
            County = county;
            Country = country;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return AddressLine1;
            yield return City;
            yield return County;
            yield return Country;
            yield return PostCode;
        }
    }
}
