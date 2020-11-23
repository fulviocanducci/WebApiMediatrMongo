using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Commands.FriendCommands
{
    public class FriendGetByIdCommandHandler : IRequestHandler<FriendGetByIdCommand, Friend>
    {
        public FriendGetByIdCommandHandler(FriendRepositoryAbstract friendRepository)
        {
            FriendRepository = friendRepository;
        }

        public FriendRepositoryAbstract FriendRepository { get; }

        public async Task<Friend> Handle(FriendGetByIdCommand request, CancellationToken cancellationToken)
        {
            return await FriendRepository.FindAsync(request.Id);
        }
    }
}
