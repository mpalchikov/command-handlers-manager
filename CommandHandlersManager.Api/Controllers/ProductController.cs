using CHM.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHandlersManager.Api.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("api/products/publish")]
        public async Task<IActionResult> PublishMessages()
        {
            var command = new ProductPublishCommand();
            await _mediator.Send(command);
            return Ok();
        }
    }
}
