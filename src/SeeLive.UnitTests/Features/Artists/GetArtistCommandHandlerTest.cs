using Microsoft.Extensions.Logging;
using Moq;
using SeeLive.Domain.Features.Artists;
using System.Threading;
using System.Threading.Tasks;
using SeeLive.Domain.Entities;
using Xunit;

namespace SeeLive.Api.UnitTests.Features.Artists
{
    public class GetArtistCommandHandlerTest
    {
        private readonly Mock<IArtistRepository> _artistRepositoryMock;

        public GetArtistCommandHandlerTest()
        {
            _artistRepositoryMock = new Mock<IArtistRepository>();
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
