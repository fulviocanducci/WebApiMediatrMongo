using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    [ApiController]
    public class ViewController : ControllerBase
    {

        public static List<Friend> Friends = new List<Friend>
        {
            new Friend { Id = "1", Name = "Name 1", Like = true},
            new Friend { Id = "2", Name = "Name 2", Like = true},
            new Friend { Id = "3", Name = "Name 3", Like = true}
        };


        [HttpGet("/source/{id}.{format}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Friend))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [FormatFilter]
        public IActionResult GetItems(string id)
        {
            return Ok(Friends.Where(c => c.Id == id).FirstOrDefault());
        }
    }
}
