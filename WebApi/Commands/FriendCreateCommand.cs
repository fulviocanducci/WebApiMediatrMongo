using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Commands.Friend
{
    public class FriendCreateCommand : IRequest<Models.Friend>
    {
        [Required()]
        public string Name { get; set; }

        [Required()]
        public bool Like { get; set; }
    }
}
