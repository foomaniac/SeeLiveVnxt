using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeeLive.Api.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using SeeLive.Domain.AggregatesModel.ArtistAggregate;

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

            var result = await _mediator.Send(createArtistCommand);

            return Ok(result);
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

            return Ok(new Artist("Sample Artist", "Amazing Artist", ""));
        }
    }
}
