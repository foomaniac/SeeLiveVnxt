using System;

namespace SeeLive.Domain.Features.Events
{
    public class CreateEventCommand : IRequest<Event>
    {
        public string Name { get; private set; }
        public string Bio { get; private set; }

        public DateTime EventDateTime { get; private set; }
        public int VenueId { get; private set; }

        public CreateEventCommand(string name, string bio, int venueId )
        {
            Name = name;
            Bio = bio;
            VenueId = venueId;
        }
    }
}
