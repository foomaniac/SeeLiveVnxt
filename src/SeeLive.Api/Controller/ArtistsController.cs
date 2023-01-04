namespace SeeLive.Api.Controller
{
    [ApiController]
    [Route("[controller]")]
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
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<bool>> CreateArtist([FromBody]CreateArtistCommand createArtistCommand)
        {
            _logger.LogInformation($"--Create Artist called - Name: {createArtistCommand.Name}, WebAddress: {createArtistCommand.WebAddress}");

            Artist artist = await _mediator.Send(createArtistCommand);

            return CreatedAtAction(nameof(Get), new {artistId = artist.Id}, artist);
        }

        [HttpGet("{artistId}")]

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<Artist>> Get(int artistId)
        {
            _logger.LogInformation("--Request to get Artist for id {0}",artistId);

            if (artistId == default) return BadRequest(artistId);

            Artist artist = await _mediator.Send(new GetArtistCommand() { ArtistId = artistId });
            
            if (artist == null) return NotFound(artistId);

            return  Ok(artist);
        }
    }
}
