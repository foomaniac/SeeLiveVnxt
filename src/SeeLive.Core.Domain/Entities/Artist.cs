using System;

namespace SeeLive.Core.Domain
{
    public class Artist
    {
        [Key]
        public int Id {get; set;}

        public string Name {get; set;}

        public string Bio {get; set;}

        public string City {get; set;}

        public string WebAddress {get; set;}

    }
}
