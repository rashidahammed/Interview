﻿using INT.Domain.Domain.Core.Repositories;
using INT.Domain.Model;

namespace INT.Domain.Domain.Interfaces
{
    public interface IUserRoleRepositories : IGenericRepository<UserRole>
    {
        public Task<bool> AddOrUpdateUserRoles(long userId, List<int> roleIds, long currentUserId);
    }
}
  
