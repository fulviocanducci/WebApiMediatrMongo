using MediatR;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Commands.FriendCommands
{
    public class FriendGetCommand : IRequest<IList<Friend>>
    {

    }
}
