using Canducci.MongoDB.Repository;
using WebApi.Models;
namespace WebApi.Repositories
{
    public abstract class FriendRepositoryAbstract : Repository<Friend>
    {
        public FriendRepositoryAbstract(IConnect connect) : base(connect)
        {
        }
    }
}
