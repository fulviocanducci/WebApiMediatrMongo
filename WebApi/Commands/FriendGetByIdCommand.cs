using MediatR;
using WebApi.Models;

namespace WebApi.Commands
{
    public class FriendGetByIdCommand : IRequest<Friend>
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
}
