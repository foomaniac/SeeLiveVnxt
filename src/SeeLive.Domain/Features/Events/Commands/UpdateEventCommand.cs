using System;

namespace SeeLive.Domain.Features.Events.Commands
{
    public class UpdateEventCommand : IRequest<Event>
    {
        public int EventId { get; set; }
        public string Name { get; private set; }
        public string Bio { get; private set; }
        public int? VenueId { get; private set; }

        public UpdateEventCommand(int eventId, string name, string bio, int? venueId)
        {
            EventId = eventId;
            Name = name;
            Bio = bio;
            VenueId = venueId;
        }
    }
}
