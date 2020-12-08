using Canducci.MongoDB.Repository;

namespace WebApi.Repositories
{
    public sealed class UserRepository : UserRepositoryAbstract
    {
        public UserRepository(IConnect connect) : base(connect)
        {
        }
    }
}
