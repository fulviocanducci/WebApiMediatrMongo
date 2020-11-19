using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Commands
{
    public class FriendGetCommandHandler : IRequestHandler<FriendGetCommand, IList<Friend>>
    {
        public FriendGetCommandHandler(FriendRepositoryAbstract friendRepository)
        {
            FriendRepository = friendRepository;
        }

        public FriendRepositoryAbstract FriendRepository { get; }

        public async Task<IList<Friend>> Handle(FriendGetCommand request, CancellationToken cancellationToken)
        {
            return await FriendRepository.AllAsync();
        }
    }
}
