namespace WebApi.Services
{
    public interface IPassword
    {
        (string Salt, string Hashed) Hash(string password);
        bool Valid(string password, string salt, string hashed);
    }
}
