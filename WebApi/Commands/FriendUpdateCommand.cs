using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Commands.Friend
{
    public class FriendUpdateCommand : IRequest<bool>
    {
        [Required()]
        public string Id { get; set; }

        [Required()]
        public string Name { get; set; }

        [Required()]
        public bool Like { get; set; }
    }
}
