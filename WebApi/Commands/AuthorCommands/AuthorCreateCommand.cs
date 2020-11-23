using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using WebApi.Models;

namespace WebApi.Commands.AuthorCommands
{
    public class AuthorCreateCommand : IRequest<Author>
    {
        [Required()]
        public string Name { get; set; }

        [Required()]
        public DateTime Created { get; set; }
    }
}
