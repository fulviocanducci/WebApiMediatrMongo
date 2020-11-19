using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Repositories;

namespace WebApi.Commands.Friend
{
    public class FriendGetCommandHandler : IRequestHandler<FriendGetCommand, IList<Models.Friend>>
    {
        public FriendGetCommandHandler(FriendRepositoryAbstract friendRepository)
        {
            FriendRepository = friendRepository;
        }

        public FriendRepositoryAbstract FriendRepository { get; }

        public async Task<IList<Models.Friend>> Handle(FriendGetCommand request, CancellationToken cancellationToken)
        {
            return await FriendRepository.AllAsync();
        }
    }
}
