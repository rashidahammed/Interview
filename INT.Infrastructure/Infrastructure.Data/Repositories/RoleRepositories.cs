using INT.Domain.Domain.Interfaces;
using INT.Domain.Model;
using INT.Infrastructure.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace INT.Infrastructure.Infrastructure.Data.Repositories
{
    public class RoleRepositories : GenericRepository<Role>, IRoleRepositories
    {
        public RoleRepositories(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> DoesRoleExist(string Name,string NameHi, int? RoleId)
        {
            return await _context.Roles.Where(x => (x.Name == Name || x.NameHi == NameHi) && x.Id!= RoleId).AnyAsync();
        }
        public async Task<bool> DoRolesExistAsync(List<int> roleIds)
        {
            var existingCount = await _context.Roles
                .Where(r => roleIds.Contains(r.Id))
                .CountAsync();

            return existingCount == roleIds.Count;
        }
    }
}
