using Canducci.MongoDB.Repository;
using WebApi.Models;
namespace WebApi.Repositories
{
    public abstract class UserRepositoryAbstract : Repository<User>
    {
        public UserRepositoryAbstract(IConnect connect) : base(connect)
        {
        }
    }
}
