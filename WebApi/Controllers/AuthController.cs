using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using WebApi.Commands.UserCommands;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IMediator Mediator { get; }

        public AuthController(IMediator mediator)
        {
            Mediator = mediator;
        }

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize()]
        //public async Task<IActionResult> Create(UserCreateCommand command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetUser()
        {
            if (User.Identity.IsAuthenticated == false) return NotFound();
            string email = User.Identity.Name;
            return Ok(await Mediator.Send(new UserGetByEmailCommand(email)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenValidate))]
        public async Task<IActionResult> Login(
            [FromServices] SigningConfigurations signingConfigurations,
            [FromServices] TokenConfigurations tokenConfigurations,
            UserLoginCommand command)
        {
            var result = await Mediator.Send(command);
            if (result.IsAuthentication)
            {

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new GenericIdentity(result.User.Email, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.NameId, result.User.Id),
                        new Claim(JwtRegisteredClaimNames.Email, result.User.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, result.User.Email),
                        new Claim(JwtRegisteredClaimNames.UniqueName, result.User.Email)
                    }
                );

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                SecurityToken securityToken = handler.CreateToken(tokenConfigurations, signingConfigurations, claimsIdentity);
                string token = handler.WriteToken(securityToken);

                return Ok(TokenValidate.Create(1, "Login Succeeded", handler.DateCreateToken(), handler.DateExpirationToken(), token));
            }
            return NotFound();
        }
    }
}
