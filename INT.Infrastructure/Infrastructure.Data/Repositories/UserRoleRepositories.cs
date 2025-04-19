using INT.Domain.Domain.Interfaces;
using INT.Domain.Model;
using INT.Infrastructure.Infrastructure.Data.Context;

namespace INT.Infrastructure.Infrastructure.Data.Repositories
{
    public class UserRoleRepositories : GenericRepository<UserRole>, IUserRoleRepositories
    {
        public UserRoleRepositories(ApplicationDbContext context) : base(context)
        {
        }
    }
}
