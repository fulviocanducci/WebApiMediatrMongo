using MediatR;
using WebApi.Models;

namespace WebApi.Commands.UserCommands
{
    public class UserGetByEmailCommand: IRequest<User>
    {
        public UserGetByEmailCommand(string email)
        {
            Email = email;
        }
        public string Email { get; }
    }
}
