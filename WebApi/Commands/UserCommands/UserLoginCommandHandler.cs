using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Repositories;
using WebApi.Services;

namespace WebApi.Commands.UserCommands
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserLoginResult>
    {
        public UserRepositoryAbstract UserRepository { get; }
        public IPassword Password { get; }

        public UserLoginCommandHandler(UserRepositoryAbstract userRepository, IPassword password)
        {
            UserRepository = userRepository;
            Password = password;
        }

        public async Task<UserLoginResult> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await UserRepository.FindAsync(x => x.Email == request.Email);
            if (user == null)
            {
                return new UserLoginResult();
            }
            var isAuthentication = Password.Valid(request.Password, user.Salt, user.Password);
            return new UserLoginResult(user, isAuthentication);
        }
    }
}
