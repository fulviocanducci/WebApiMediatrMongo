using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Repositories;

namespace WebApi.Commands.Friend
{
    public class FriendGetByIdCommand : IRequest<Models.Friend>
    {
        public string Id { get; }
        public FriendGetByIdCommand(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new System.ArgumentException($"'{nameof(id)}' cannot be null or empty", nameof(id));
            }
            Id = id;
        }
    }

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
