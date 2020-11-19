using MediatR;
using System.Collections.Generic;

namespace WebApi.Commands.Friend
{
    public class FriendGetCommand : IRequest<IList<Models.Friend>>
    {

    }
}
