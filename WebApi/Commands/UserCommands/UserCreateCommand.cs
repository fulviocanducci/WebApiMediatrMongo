using MediatR;
using System.ComponentModel.DataAnnotations;
using WebApi.Models;

namespace WebApi.Commands.UserCommands
{
    public class UserCreateCommand: IRequest<User>
    {
        [Required()]
        public string Name { get; set; }

        [Required()]
        [EmailAddress()]
        public string Email { get; set; }

        [Required()]
        public string Password { get; set; }
    }
}
