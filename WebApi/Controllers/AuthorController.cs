using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Commands.AuthorCommands;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize("Bearer")]
    public class AuthorController : ControllerBase
    {
        public IMediator Mediator { get; }

        public AuthorController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Author>))]
        public async Task<IEnumerable<Author>> Get()
        {
            return await Mediator.Send(new AuthorGetCommand());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Author))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string id)
        {
            var model = await Mediator.Send(new AuthorGetByIdCommand(id));
            if (model != null)
            {
                return Ok(model);
            }
            return NotFound(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Author))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] AuthorCreateCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await Mediator.Send(command));
                }
                return BadRequest();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status304NotModified, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(string id, [FromBody] AuthorUpdateCommand command)
        {
            try
            {
                if (id != command.Id)
                {
                    return NotFound(id);
                }
                if (ModelState.IsValid)
                {
                    var model = await Mediator.Send(command);
                    return model ? Ok(model) : StatusCode(304, model);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return NotFound(id);
                }
                var model = await Mediator.Send(new AuthorRemoveByIdCommand(id));
                return model ? Ok(model) : NotFound(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
