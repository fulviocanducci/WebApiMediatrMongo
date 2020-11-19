using Canducci.MongoDB.Repository;

namespace WebApi.Repositories
{
    public sealed class FriendRepository : FriendRepositoryAbstract
    {
        public FriendRepository(IConnect connect) : base(connect)
        {
        }
    }
}
