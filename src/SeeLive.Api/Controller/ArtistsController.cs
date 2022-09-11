using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using SeeLive.Domain.Features.Artists;
using SeeLive.Domain.Models;


namespace SeeLive.Api.Controller
{
    [Route("artists")]
    [Produces("application/json")]
    public class ArtistsController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<ArtistsController> _logger;

        public ArtistsController(IMediator mediator, ILogger<ArtistsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost]
        [Route("create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<bool>> CreateArtist([FromBody]CreateArtistCommand createArtistCommand)
        {
            _logger.LogInformation($"--Create Artist called - Name: {createArtistCommand.Name}, WebAddress: {createArtistCommand.WebAddress}");

            Artist artist = await _mediator.Send(createArtistCommand);

            return CreatedAtAction(nameof(GetArtist),new {id = artist.Id}, artist);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetArtist(int id)
        {
            if (id == default)
            {
                return BadRequest(id);
            }

            Artist artist = await _mediator.Send(new GetArtistCommand() { ArtistId = id });

            if (artist == null)
            {
                return NotFound(id);
            }

            return  Ok(artist);
        }
    }
}
