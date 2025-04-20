using INT.Application.Application.Interfaces;
using INT.Application.Contexts;

namespace INT.Infrastructure.Contexts
{
    public class CurrentUserContext : ICurrentUserContext
    {
        public UserContext User { get; private set; }

        public void SetUserContext(UserContext user)
        {
            User = user;
        }
    }
}
