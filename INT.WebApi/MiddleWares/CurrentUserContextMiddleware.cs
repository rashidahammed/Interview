using INT.Application.Application.Interfaces;
using INT.Application.Contexts;
using INT.Utility;
using INT.Utility.Resources;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static INT.Utility.Enums;

namespace INT.WebApi.MiddleWares
{
    public class CurrentUserContextMiddleware
    {
        private readonly RequestDelegate _next;
        public CurrentUserContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            var userContext = context.RequestServices.GetRequiredService<ICurrentUserContext>();
            var userService = context.RequestServices.GetRequiredService<IUserServices>();

            IEnumerable<Claim> claims = null;
            var path = context.Request.Path.Value?.ToLower();

            var skipPaths = new[] { "/login", "/swagger", "/health" };

            if (!skipPaths.Any(p => path.StartsWith(p)))
            {
                try
                {
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
                            await context.Response.WriteAsync(AppResource.Unauthorized);
                            return;
                        }
                        string? userId = claims.FirstOrDefault(x => x.Type == ClaimTypeConstants.UserId)?.Value;


                        if (!string.IsNullOrEmpty(userId))
                        {
                            var lagn = CultureInfo.CurrentUICulture?.Name != null && CultureInfo.CurrentUICulture?.Name == "en" ? Language.English : Language.Hindi;


                            var userDetails = await userService.GetById(Convert.ToInt64(userId));

                            if (userDetails.Success && userDetails.Data != null)
                            {
                                userContext.SetUserContext(new UserContext
                                {
                                    UserId = userDetails.Data.Id,
                                    Email = userDetails.Data.Email,
                                    Language = lagn,
                                    UserName = userDetails.Data.Name
                                });
                            }
                            else
                            {
                                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                                await context.Response.WriteAsync(AppResource.Unauthorized);
                                return;
                            }
                        }
                    }
                    if (claims == null || !claims.Any() || string.IsNullOrEmpty(claims.FirstOrDefault(x => x.Type == ClaimTypeConstants.UserId)?.Value))
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync(AppResource.Unauthorized);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(AppResource.CommonError);
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync(AppResource.Unauthorized);
                    return;
                }
            }

            await _next(context);
        }
    }
}
