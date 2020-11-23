using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Commands.AuthorCommands;
using WebApi.Repositories;

namespace WebApi.Commands.FriendCommands
{
    public class AuthorRemoveByIdCommandHandler : IRequestHandler<AuthorRemoveByIdCommand, bool>
    {
        public AuthorRemoveByIdCommandHandler(AuthorRepositoryAbstract authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        public AuthorRepositoryAbstract AuthorRepository { get; }

        public async Task<bool> Handle(AuthorRemoveByIdCommand request, CancellationToken cancellationToken)
        {
            return await AuthorRepository.DeleteAsync(request.Id);
        }
    }
}
