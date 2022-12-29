using System;

namespace SeeLive.Domain.Features.Events
{
    public class CreateEventCommand : IRequest<Event>
    {
        public string Name { get; private set; }
        public string Bio { get; private set; }        

        public CreateEventCommand(string name, string bio)
        {
            Name = name;
            Bio = bio;            
        }
    }
}
