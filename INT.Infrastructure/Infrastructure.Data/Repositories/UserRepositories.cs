using INT.Domain.Domain.Interfaces;
using INT.Domain.Model;
using INT.Infrastructure.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Infrastructure.Infrastructure.Data.Repositories
{
    public class UserRepositories : GenericRepository<User>, IUserRepositories
    {
        public UserRepositories(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> DoesUserExist(string userName, string email, long? userId)
        {
            return await _context.Users.Where(x => (x.UserName == userName || x.Email == email) && x.Id != userId).AnyAsync();
        }

        //public async Task<bool> IUserRepositories.DoesUserExist(string userName, string email)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
