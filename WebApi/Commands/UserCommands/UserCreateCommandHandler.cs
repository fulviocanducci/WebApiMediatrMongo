using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Services;

namespace WebApi.Commands.UserCommands
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, User>
    {
        public UserRepositoryAbstract UserRepository { get; }
        public IPassword Password { get; }

        public UserCreateCommandHandler(UserRepositoryAbstract userRepository, IPassword password)
        {
            UserRepository = userRepository;
            Password = password;
        }

        public async Task<User> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            (string Salt, string Hashed) p = Password.Hash(request.Password);
            var user = await UserRepository.AddAsync(new User
            {
                Email = request.Email,
                Password = p.Hashed,
                Salt = p.Salt,
                Name = request.Name,
                Created = System.DateTime.Now
            });
            return user;
        }
    }
}
