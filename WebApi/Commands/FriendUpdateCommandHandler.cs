using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Repositories;

namespace WebApi.Commands.Friend
{
    public class FriendUpdateCommandHandler : IRequestHandler<FriendUpdateCommand, bool>
    {
        public FriendUpdateCommandHandler(FriendRepositoryAbstract friendRepository)
        {
            FriendRepository = friendRepository;
        }

        public FriendRepositoryAbstract FriendRepository { get; }
        public async Task<bool> Handle(FriendUpdateCommand request, CancellationToken cancellationToken)
        {
            return await FriendRepository.EditAsync(request.Id, new Models.Friend
            {
                Id = request.Id,
                Name = request.Name,
                Like = request.Like
            });
        }
    }
}
