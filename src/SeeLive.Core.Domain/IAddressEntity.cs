using System;
using System.Collections.Generic;
using System.Text;

namespace SeeLive.Core.Domain
{
    public interface IAddressEntity
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
    }
}
