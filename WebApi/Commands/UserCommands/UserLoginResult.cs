using WebApi.Models;

namespace WebApi.Commands.UserCommands
{
    public class UserLoginResult
    {
        public UserLoginResult()
        {
        }

        public UserLoginResult(User user, bool isAuthentication)
        {
            User = user;
            IsAuthentication = isAuthentication;
        }

        public User User { get; } = null;
        public bool IsAuthentication { get; } = false;
    }
}
