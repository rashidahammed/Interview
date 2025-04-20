using INT.Domain.Domain.Core.Repositories;
using INT.Domain.Model;

namespace INT.Domain.Domain.Interfaces
{
    public interface IUserRepositories : IGenericRepository<User>
    {
        public Task<bool> DoesUserExist(string userName, string email, long? value);
        public Task<UserDetails> GetUseDetailsById(long userId);
        public Task<List<UserDetails>> GetAlLUsers();
        public Task<UserDetails> GetUseDetailsForLogin(string userName, string password);

    }
}

