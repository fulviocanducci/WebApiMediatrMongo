using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Commands.AuthorCommands
{
    public class AuthorUpdateCommandHandler : IRequestHandler<AuthorUpdateCommand, bool>
    {
        public AuthorUpdateCommandHandler(AuthorRepositoryAbstract authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        public AuthorRepositoryAbstract AuthorRepository { get; }

        public async Task<bool> Handle(AuthorUpdateCommand request, CancellationToken cancellationToken)
        {
            return await AuthorRepository.EditAsync(request.Id, new Author
            {
                Id = request.Id,
                Name = request.Name,
                Created = request.Created
            });
        }
    }
}
