using Microsoft.Extensions.Logging;
using Moq;
using SeeLive.Domain.Features.Artists;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using SeeLive.Api.UnitTests.Fixtures;
using SeeLive.Domain.Features.Events;
using SeeLive.Infrastructure.Repositories;
using Microsoft.VisualBasic;
using System.Data.Common;
using SeeLive.Domain.Features.Events.Interfaces;
using SeeLive.Domain.Features.Events.Handlers;
using SeeLive.Domain.Features.Events.Commands;

namespace SeeLive.Api.UnitTests.Features.Events
{
    public class UpdateEventCommandHandlerTest : IClassFixture<SeeLiveInMemoryFixture>
    {

        SeeLiveInMemoryFixture _fixture;
        IEventsRepository _eventsRepository;
        IVenuesRepository _venuesRepository;
        public UpdateEventCommandHandlerTest(SeeLiveInMemoryFixture fixture)
        {
            _fixture = fixture;
            _eventsRepository = new EventsRepository(_fixture.SeeLiveContext);            
            _venuesRepository = new VenuesRepository(_fixture.SeeLiveContext);
       }

        [Fact]
        public async Task handler_returns_valid_event_when_update_event_called()
        {
            //Arrange          
            var createEventloggerMock = new Mock<ILogger<CreateEventCommandHandler>>();
            var createNewEventHandler = new CreateEventCommandHandler(_eventsRepository, createEventloggerMock.Object);
            var updateEventloggerMock = new Mock<ILogger<UpdateEventCommandHandler>>();
            var updateEventHandler = new UpdateEventCommandHandler(_eventsRepository, _venuesRepository, updateEventloggerMock.Object);            
            var newEventCommand = new CreateEventCommand("Test Event", "Event Testing");
            var updateEventCommand = new UpdateEventCommand(default, "Updated Event", "Updated Testing Event", null);
            var cancellationToken = new CancellationToken();

            //Act            
            Event newEvent = await createNewEventHandler.Handle(newEventCommand, cancellationToken);

            //Assert
            Assert.NotNull(newEvent);
            Assert.NotEqual(default, newEvent.Id);

            //Update
            updateEventCommand.EventId = newEvent.Id;
            Event updatedEvent = await updateEventHandler.Handle(updateEventCommand, cancellationToken);

            //Assert
            Assert.NotNull(updatedEvent);
            Assert.NotEqual(default, updatedEvent.Id);
            Assert.Equal(updatedEvent.Name, updateEventCommand.Name);
            Assert.Equal(updatedEvent.Bio, updateEventCommand.Bio);
        }   

        
    }
}
