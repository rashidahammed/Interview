using INT.Application.Application.Interfaces;
using INT.Application.Contexts;
using INT.Infrastructure.Infrastructure.Data.Context;
using INT.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;
using static INT.Domain.Domain.Constants.Enums;

namespace INT.WebApi.MiddleWares
{
    public class CurrentUserContextMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ApplicationDbContext _dbContext;

        //public CurrentUserContextMiddleware(RequestDelegate next, ApplicationDbContext dbContext)
        //{
           public CurrentUserContextMiddleware(RequestDelegate next)
            {
                _next = next;
            //_dbContext = dbContext;
        }

        public async Task InvokeAsync(HttpContext context, ICurrentUserContext currentUserContext)
        {
            IEnumerable<Claim> claims = null;
            var path = context.Request.Path.Value?.ToLower();

            var skipPaths = new[] { "/api/auth/login", "/api/auth/register", "/swagger", "/health" };

            if (skipPaths.Any(p => path.StartsWith(p)))
            {
                await _next(context);
            }

            try
            {
                // can be added Encription/decription for Tocken for more security
                var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                if (authHeader != null)
                {
                    var token = authHeader.Substring("Bearer ".Length).Trim();
                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(token);
                    claims = jwtToken.Claims.ToList();
         

                    if (claims == null || !claims.Any())
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Unauthorized: Invalid or missing claims.");
                        return;
                    }
                    string? UserId = claims.FirstOrDefault(x => x.Type == ClaimTypeConstants.UserId)?.Value;


                    if (!string.IsNullOrEmpty(UserId))
                    {
                        if (context.User.Identity is { IsAuthenticated: true })
                        {
                            var userContext = new UserContext
                            {
                                UserId = Convert.ToInt64(UserId),
                                Email = "",
                                Language= Language.Arabic,
                                RoleId=1,
                                UserName="rashid"
                            };
                            currentUserContext.SetUserContext(userContext);
                        }
                    }
                }
                if (claims == null || !claims.Any() || string.IsNullOrEmpty(claims.FirstOrDefault(x => x.Type == ClaimTypeConstants.UserId)?.Value))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized: Invalid or missing claims.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while setting logged-in user: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Invalid or missing claims.");
                return;
            }
            await _next(context);
        }
    }
}
