using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Commands.UserCommands
{
    public class UserGetByEmailCommandHandler: IRequestHandler<UserGetByEmailCommand, User>
    {
        public UserRepositoryAbstract UserRepository { get; }
        public UserGetByEmailCommandHandler(UserRepositoryAbstract userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task<User> Handle(UserGetByEmailCommand request, CancellationToken cancellationToken)
        {
            return await UserRepository.FindAsync(x => x.Email == request.Email);
        }
    }
}
