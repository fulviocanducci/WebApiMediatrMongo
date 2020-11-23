using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Commands.FriendCommands
{
    public class FriendCreateCommandHandler : IRequestHandler<FriendCreateCommand, Friend>
    {
        public FriendCreateCommandHandler(FriendRepositoryAbstract friendRepository)
        {
            FriendRepository = friendRepository;
        }

        public FriendRepositoryAbstract FriendRepository { get; }

        public async Task<Friend> Handle(FriendCreateCommand request, CancellationToken cancellationToken)
        {
            return await FriendRepository.AddAsync(new Friend
            {
                Like = request.Like,
                Name = request.Name
            });
        }
    }
}
