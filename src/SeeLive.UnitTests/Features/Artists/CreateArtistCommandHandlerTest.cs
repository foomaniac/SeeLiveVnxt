using Microsoft.Extensions.Logging;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using SeeLive.Domain.Features.Artists.Handlers;
using SeeLive.Domain.Features.Artists.Commands;
using SeeLive.Domain.Features.Artists.Interfaces;
using SeeLive.Domain.Features.Artists;

namespace SeeLive.Api.UnitTests.Features.Artists
{
    public class CreateArtistCommandHandlerTest
    {
        private readonly Mock<IArtistsRepository> _artistRepositoryMock;

        public CreateArtistCommandHandlerTest()
        {
            _artistRepositoryMock = new Mock<IArtistsRepository>();
        }

        [Fact]
        public async Task handler_returns_valid_artist_when_create_artist_called_createdAsync()
        {
            //Arrange
            var fakeArtistCmd = FakeArtistRequest();

            _artistRepositoryMock.Setup(artistRepo => artistRepo.UnitOfWork.SaveEntitiesAsync(default))
                .Returns(Task.FromResult(true));

            var loggerMock = new Mock<ILogger<CreateArtistCommandHandler>>();

            //Act
            var handler = new CreateArtistCommandHandler(_artistRepositoryMock.Object, loggerMock.Object);
            var cancellationToken = new CancellationToken();
            var result = await handler.Handle(fakeArtistCmd, cancellationToken);

            //Assert
            Assert.Equivalent(FakeArtist(),result);
        }

        private static CreateArtistCommand FakeArtistRequest()
        {
            var fakeArtist = FakeArtist();

            return new CreateArtistCommand(fakeArtist.Name, fakeArtist.Bio, fakeArtist.WebAddress);
        }

        private static Artist FakeArtist()
        {
            return new Artist("Test Artist", "Test bio", "http://www.google.com");
        }
    }
}
