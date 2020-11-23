using Canducci.MongoDB.Repository;

namespace WebApi.Repositories
{
    public sealed class AuthorRepository : AuthorRepositoryAbstract
    {
        public AuthorRepository(IConnect connect) : base(connect)
        {
        }
    }
}
