using MediatR;
using System.ComponentModel.DataAnnotations;
using WebApi.Models;

namespace WebApi.Commands.UserCommands
{
    public class UserLoginCommand : IRequest<UserLoginResult>
    {        
        [Required()]
        [EmailAddress()]
        public string Email { get; set; }

        [Required()]
        public string Password { get; set; }
    }
}
