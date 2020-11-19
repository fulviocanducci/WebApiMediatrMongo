using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Repositories;

namespace WebApi.Commands.Friend
{
    public class FriendGetByIdCommandHandler : IRequestHandler<FriendGetByIdCommand, Models.Friend>
    {
        public FriendGetByIdCommandHandler(FriendRepositoryAbstract friendRepository)
        {
            FriendRepository = friendRepository;
        }

        public FriendRepositoryAbstract FriendRepository { get; }

        public async Task<Models.Friend> Handle(FriendGetByIdCommand request, CancellationToken cancellationToken)
        {
            return await FriendRepository.FindAsync(request.Id);
        }
    }
}
