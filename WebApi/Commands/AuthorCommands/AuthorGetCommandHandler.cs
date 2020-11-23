using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Commands.AuthorCommands
{
    public class AuthorGetCommandHandler : IRequestHandler<AuthorGetCommand, IList<Author>>
    {
        public AuthorGetCommandHandler(AuthorRepositoryAbstract authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        public AuthorRepositoryAbstract AuthorRepository { get; }

        public async Task<IList<Author>> Handle(AuthorGetCommand request, CancellationToken cancellationToken)
        {
            return await AuthorRepository.AllAsync();
        }
    }
}
