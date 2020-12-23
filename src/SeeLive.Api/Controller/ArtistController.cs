using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeeLive.Api.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SeeLive.Api.Controller
{
    public class ArtistController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<ArtistController> _logger;

        public ArtistController(IMediator mediator, ILogger<ArtistController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [Route("create")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<bool>> CreateArtist([FromBody]CreateArtistCommand createArtistCommand)
        {
            _logger.LogInformation($"--Create Artist called - Name: {createArtistCommand.Name}, WebAddress: {createArtistCommand.WebAddress}");

            var result = await _mediator.Send(createArtistCommand);

            if (!result)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
