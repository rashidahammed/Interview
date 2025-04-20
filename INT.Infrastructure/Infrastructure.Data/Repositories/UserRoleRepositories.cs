using INT.Application.Contexts;
using INT.Domain.Domain.Interfaces;
using INT.Domain.Model;
using INT.Infrastructure.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace INT.Infrastructure.Infrastructure.Data.Repositories
{
    public class UserRoleRepositories : GenericRepository<UserRole>, IUserRoleRepositories
    {
        public UserRoleRepositories(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> AddOrUpdateUserRoles(long userId, List<int> roleIds, long currentUserId)
        {
            if (roleIds == null || !roleIds.Any())
            {
                return false; 
            }

            var existingRoleIds = await _context.UserRoles
                .Where(r => roleIds.Contains(r.RoleId) && r.UserId == userId && !r.IsDeleted)
                .ToListAsync();

            if (existingRoleIds.Any())
            {
                existingRoleIds.ForEach(r => {
                    r.IsDeleted = true;
                    r.LastModifiedBy = currentUserId;
                    r.LastModifiedOn = DateTime.Now;
                });

                await _context.SaveChangesAsync();
            }

            var existingRoleIdsSet = existingRoleIds?.Select(x => x.RoleId).ToHashSet() ?? new HashSet<int>();
            var missingRoleIds = roleIds.Where(id => !existingRoleIdsSet.Contains(id)).ToList();

            if (missingRoleIds.Any())
            {
                var newUserRoles = missingRoleIds.Select(id => new UserRole
                {
                    RoleId = id,
                    UserId = userId,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    CreatedBy = currentUserId
                }).ToList();

                await _context.UserRoles.AddRangeAsync(newUserRoles);
                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
}
