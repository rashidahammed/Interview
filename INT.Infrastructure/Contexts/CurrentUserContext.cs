using INT.Application.Application.Interfaces;
using INT.Application.Contexts;

namespace INT.Infrastructure.Contexts
{
    public class CurrentUserContext : ICurrentUserContext
    {
        private static readonly AsyncLocal<UserContext> _currentUser = new();
        public UserContext GetUserContext() => _currentUser.Value;

        public void SetUserContext(UserContext userContext)
        {
            _currentUser.Value = userContext;
        }
    }
}
