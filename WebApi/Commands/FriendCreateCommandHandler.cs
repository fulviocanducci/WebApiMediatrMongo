using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Repositories;

namespace WebApi.Commands.Friend
{
    public class FriendCreateCommandHandler : IRequestHandler<FriendCreateCommand, Models.Friend>
    {
        public FriendCreateCommandHandler(FriendRepositoryAbstract friendRepository)
        {
            FriendRepository = friendRepository;
        }

        public FriendRepositoryAbstract FriendRepository { get; }

        public async Task<Models.Friend> Handle(FriendCreateCommand request, CancellationToken cancellationToken)
        {
            return await FriendRepository.AddAsync(new Models.Friend
            {
                Like = request.Like,
                Name = request.Name
            });
        }
    }
}
