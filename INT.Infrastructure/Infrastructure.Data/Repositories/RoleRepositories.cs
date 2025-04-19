using INT.Domain.Domain.Interfaces;
using INT.Domain.Model;
using INT.Infrastructure.Infrastructure.Data.Context;

namespace INT.Infrastructure.Infrastructure.Data.Repositories
{
    public class RoleRepositories : GenericRepository<Role>, IRoleRepositories
    {
        public RoleRepositories(ApplicationDbContext context) : base(context)
        {
        }
    }
}
