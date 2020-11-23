using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Commands.AuthorCommands
{
    public class AuthorUpdateCommand : IRequest<bool>
    {
        [Required()]
        public string Id { get; set; }

        [Required()]
        public string Name { get; set; }

        [Required()]
        public DateTime Created { get; set; }
    }
}
