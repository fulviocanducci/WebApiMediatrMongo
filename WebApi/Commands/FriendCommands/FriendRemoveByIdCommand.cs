using MediatR;

namespace WebApi.Commands.FriendCommands
{
    public class FriendRemoveByIdCommand : IRequest<bool>
    {
        public string Id { get; }
        public FriendRemoveByIdCommand(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new System.ArgumentException($"'{nameof(id)}' cannot be null or empty", nameof(id));
            }
            Id = id;
        }
    }
}
