using INT.Domain.Domain.Core.Repositories;
using INT.Domain.Model;

namespace INT.Domain.Domain.Interfaces
{
    public interface IRoleRepositories : IGenericRepository<Role>
    {
        public Task<bool> DoesRoleExist(string Name, string NameHi, int? RoleId);
        public Task<bool> DoRolesExistAsync(List<int> roleIds);
    }
}
  
