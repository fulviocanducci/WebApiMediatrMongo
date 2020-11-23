using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Commands.AuthorCommands
{
    public class AuthorGetByIdCommandHandler : IRequestHandler<AuthorGetByIdCommand, Author>
    {
        public AuthorGetByIdCommandHandler(AuthorRepositoryAbstract authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        public AuthorRepositoryAbstract AuthorRepository { get; }

        public async Task<Author> Handle(AuthorGetByIdCommand request, CancellationToken cancellationToken)
        {
            return await AuthorRepository.FindAsync(request.Id);
        }
    }
}
