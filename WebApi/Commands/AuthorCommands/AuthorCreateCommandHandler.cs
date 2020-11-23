using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Commands.AuthorCommands
{
    public class AuthorCreateCommandHandler : IRequestHandler<AuthorCreateCommand, Author>
    {
        public AuthorCreateCommandHandler(AuthorRepositoryAbstract authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        public AuthorRepositoryAbstract AuthorRepository { get; }

        public async Task<Author> Handle(AuthorCreateCommand request, CancellationToken cancellationToken)
        {
            return await AuthorRepository.AddAsync(new Author
            {
                Created = request.Created,
                Name = request.Name
            });
        }
    }
}
