using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using SeeLive.Api.Application.Commands;
using SeeLive.Domain.Features.Artists;
using SeeLive.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SeeLive.UnitTests
{
    public class NewArtistCommandHandlerTest
    {

        private readonly Mock<IArtistRepository> _artistRepositoryMock;
    
        public NewArtistCommandHandlerTest()
        {
            _artistRepositoryMock = new Mock<IArtistRepository>();    
        }

        [Fact]
        public async Task Handle_return_true_if_artist_createdAsync()
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
            Assert.True(result);
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
