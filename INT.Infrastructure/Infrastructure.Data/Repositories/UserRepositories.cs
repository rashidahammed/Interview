using Dapper;
using INT.Domain.Domain.Interfaces;
using INT.Domain.Model;
using INT.Infrastructure.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

        public async Task<UserDetails> GetUseDetailsById(long userId)
        {
            await using var connection = new SqlConnection(_context.Database.GetConnectionString());
            await connection.OpenAsync().ConfigureAwait(false);

            var parameters = new
            {
                UserId = userId,
            };

            var _result = await connection.QuerySingleOrDefaultAsync<UserDetails>(
                "sp_GetUserDetails",
                parameters,
                commandType: CommandType.StoredProcedure
            ).ConfigureAwait(false);

            return _result;
        }

        public async Task<List<UserDetails>> GetAlLUsers()
        {
            var _result = new List<UserDetails>();
            await using var connection = new SqlConnection(_context.Database.GetConnectionString());
            await connection.OpenAsync().ConfigureAwait(false);

            var result = await connection.QueryAsync<UserDetails>(
                "sp_GetUserDetails",
                commandType: CommandType.StoredProcedure
            ).ConfigureAwait(false);

            return result.ToList();
        }

        public async Task<UserDetails> GetUseDetailsForLogin(string userName, string password)
        {
            var user= await _context.Users.Where(x => x.UserName == userName && x.IsDeleted==false).FirstOrDefaultAsync();
            if(user != null)
            {
                var hasher = new PasswordHasher<User>();
                var result = hasher.VerifyHashedPassword(null, user.Password, password);
                if (result == PasswordVerificationResult.Success)
                {
                    return await GetUseDetailsById(user.Id);
                }
            }
            return null;
        }
    }
}
