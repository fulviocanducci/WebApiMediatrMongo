using Canducci.MongoDB.Repository;
using WebApi.Models;
namespace WebApi.Repositories
{
    public abstract class AuthorRepositoryAbstract : Repository<Author>
    {
        public AuthorRepositoryAbstract(IConnect connect) : base(connect)
        {
        }
    }
}
