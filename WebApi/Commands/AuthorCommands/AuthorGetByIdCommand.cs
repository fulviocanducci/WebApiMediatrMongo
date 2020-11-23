using MediatR;
using WebApi.Models;

namespace WebApi.Commands.AuthorCommands
{
    public class AuthorGetByIdCommand : IRequest<Author>
    {
        public string Id { get; }
        public AuthorGetByIdCommand(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new System.ArgumentException($"'{nameof(id)}' cannot be null or empty", nameof(id));
            }
            Id = id;
        }
    }
}
