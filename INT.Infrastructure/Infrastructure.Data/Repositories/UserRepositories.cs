using INT.Domain.Domain.Interfaces;
using INT.Domain.Model;
using INT.Infrastructure.Infrastructure.Data.Context;
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
    }
}
