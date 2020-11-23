using MediatR;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Commands.AuthorCommands
{
    public class AuthorGetCommand : IRequest<IList<Author>>
    {

    }
}
