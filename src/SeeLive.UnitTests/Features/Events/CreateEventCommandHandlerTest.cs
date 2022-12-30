using Microsoft.Extensions.Logging;
using Moq;
using SeeLive.Domain.Features.Artists;
using System.Threading;
using System.Threading.Tasks;
using SeeLive.Domain.Entities;
using Xunit;
using SeeLive.Api.UnitTests.Fixtures;
using SeeLive.Domain.Features.Events;
using SeeLive.Infrastructure.Repositories;
using SeeLive.Domain.Features.Events.Interfaces;
using SeeLive.Domain.Features.Events.Handlers;
using SeeLive.Domain.Features.Events.Commands;

namespace SeeLive.Api.UnitTests.Features.Events
{
    public class CreateEventCommandHandlerTest : IClassFixture<SeeLiveInMemoryFixture>
    {

        SeeLiveInMemoryFixture _fixture;
        IEventsRepository _eventsRepository;

        public CreateEventCommandHandlerTest(SeeLiveInMemoryFixture fixture)
        {
            _fixture = fixture;
            _eventsRepository = new EventsRepository(_fixture.SeeLiveContext);
       }

        [Fact]
        public async Task handler_returns_valid_event_when_create_event_called()
        {
            //Arrange           
            var loggerMock = new Mock<ILogger<CreateEventCommandHandler>>();
            var newEventCommand = new CreateEventCommand("Test Event", "Event Testing");

            //Act
            var handler = new CreateEventCommandHandler(_eventsRepository, loggerMock.Object);
            var cancellationToken = new CancellationToken();
            var result = await handler.Handle(newEventCommand, cancellationToken);

            //Assert
            Assert.NotNull(result);
            Assert.NotEqual(result.Id, default);
            Assert.Equal(result.Name, newEventCommand.Name);
            Assert.Equal(result.Bio, newEventCommand.Bio);
        }   
    }
}
