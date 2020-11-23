using MediatR;

namespace WebApi.Commands.AuthorCommands
{
    public class AuthorRemoveByIdCommand : IRequest<bool>
    {
        public string Id { get; }
        public AuthorRemoveByIdCommand(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new System.ArgumentException($"'{nameof(id)}' cannot be null or empty", nameof(id));
            }
            Id = id;
        }
    }
}
