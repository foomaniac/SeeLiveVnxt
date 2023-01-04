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
    public class GetArtistCommandHandlerTest
    {
        private readonly Mock<IArtistsRepository> _artistRepositoryMock;

        public GetArtistCommandHandlerTest()
        {
            _artistRepositoryMock = new Mock<IArtistsRepository>();
        }

        [Fact]
        public async Task handler_returns_valid_artist_when_valid_get_artist_call_made_createdAsync()
        {
            //Arrange
            var fakeArtistCmd = FakeArtistRequest();

            _artistRepositoryMock.Setup(artistRepo => artistRepo.GetAsync(It.IsAny<int>())).ReturnsAsync(FakeArtist);

            var loggerMock = new Mock<ILogger<GetArtistCommandHandler>>();

            //Act
            GetArtistCommandHandler handler = new GetArtistCommandHandler(_artistRepositoryMock.Object, loggerMock.Object);
            var cancellationToken = new CancellationToken();
            Artist result = await handler.Handle(fakeArtistCmd, cancellationToken);

            //Assert
            Assert.Equivalent(FakeArtist(),result);
        }

        private static GetArtistCommand FakeArtistRequest()
        {
            var fakeArtist = FakeArtist();

            return new GetArtistCommand(){ ArtistId = fakeArtist.Id};
        }

        private static Artist FakeArtist()
        {
            return new Artist(34,"Test Artist", "Test bio", "http://www.google.com");
        }
    }
}
