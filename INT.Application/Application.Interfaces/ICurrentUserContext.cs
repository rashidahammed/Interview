using INT.Application.Contexts;

namespace INT.Application.Application.Interfaces
{
    public interface ICurrentUserContext
    {
        UserContext User { get; }
        void SetUserContext(UserContext user);
    }
}
