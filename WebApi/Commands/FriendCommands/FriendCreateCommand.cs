using MediatR;
using System.ComponentModel.DataAnnotations;
using WebApi.Models;

namespace WebApi.Commands.FriendCommands
{
    public class FriendCreateCommand : IRequest<Friend>
    {
        [Required()]
        public string Name { get; set; }

        [Required()]
        public bool Like { get; set; }
    }
}
