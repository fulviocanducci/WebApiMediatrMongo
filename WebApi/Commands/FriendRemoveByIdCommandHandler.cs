using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Repositories;

namespace WebApi.Commands
{
    public class FriendRemoveByIdCommandHandler : IRequestHandler<FriendRemoveByIdCommand, bool>
    {
        public FriendRemoveByIdCommandHandler(FriendRepositoryAbstract friendRepository)
        {
            FriendRepository = friendRepository;
        }

        public FriendRepositoryAbstract FriendRepository { get; }
        public async Task<bool> Handle(FriendRemoveByIdCommand request, CancellationToken cancellationToken)
        {
            return await FriendRepository.DeleteAsync(request.Id);
        }
    }
}
