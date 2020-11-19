using MediatR;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Commands
{
    public class FriendGetCommand : IRequest<IList<Friend>>
    {

    }
}
