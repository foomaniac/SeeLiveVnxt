namespace SeeLive.Api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EventsController> _logger;

        public EventsController(IMediator mediator, ILogger<EventsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost]
        [Route("create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<bool>> CreateEvent([FromBody] CreateEventCommand createEventCommand)
        {
            _logger.LogInformation($"--Create Event called - Name: {createEventCommand.Name}");

            Event newEvent = await _mediator.Send(createEventCommand);

            return CreatedAtAction(nameof(Get), new { eventId = newEvent.Id }, newEvent);
        }

        [HttpGet("{eventId}")]

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<Event>> Get(int eventId)
        {
            _logger.LogInformation("--Request to get Event for id {0}", eventId);

            if (eventId == default) return BadRequest(eventId);

            Event existingEvent = await _mediator.Send(new GetEventQuery() { EventId = eventId});

            if (existingEvent == null) return NotFound(eventId);

            return Ok(existingEvent);
        }
    }
}
