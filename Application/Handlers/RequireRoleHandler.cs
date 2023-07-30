using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace WebApplication1;

public class RequireRoleHandler : AuthorizationHandler<RequireRoleRequirement>
{
    private readonly PostgresContext _dbContext;
    private readonly ILogger<RequireRoleHandler> _logger;

    public RequireRoleHandler(PostgresContext dbContext, ILogger<RequireRoleHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger; // Assign the injected logger to the field
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        RequireRoleRequirement requirement)
    {
   

        _logger.LogInformation("HandleRequirementAsync method entered.");

            // Check if the user is authenticated and has an authenticated user claim
            if (!context.User.Identity.IsAuthenticated)

            {
                //  Console.WriteLine($"Claim Type: {claim.Type}, Value: {claim.Value}");
                // Console.WriteLine(context);
                _logger.LogInformation("HandleRequirementAsync method failed.");
                context.Fail(); // User is not authenticated, deny access
                return;
            }
            var userIdClaim = context.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            if (userIdClaim != null)
            {
                string userIdValue = userIdClaim.Value;
                _logger.LogInformation($"User ID Claim Value: {userIdValue}");
            }

            // Get the user ID from the token or any other identifier as per your application logic
            Console.WriteLine("ClaimType"+ClaimTypes.NameIdentifier);
          //  long userId = long.Parse(context.User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"));
          //  var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);


            string userIdString = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine("uSERiDsTRING"+userIdString);
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.FireBaseId == (userIdString));
            _logger.LogInformation("HandleRequirementAsync method search.");
           // Console.WriteLine("Roleid2" + user.RoleId);

            // If the user is not found in the database or doesn't have the required role, deny access
            if (user == null || user.RoleId != requirement.RequiredRoleId)
            {
                _logger.LogInformation("HandleRequirementAsync method failed2.");
                context.Fail(); // User does not have the required role, deny access
                return;
            }

            _logger.LogInformation("HandleRequirementAsync method succeed.");
            // If the user exists and has the required role, succeed the authorization
            context.Succeed(requirement);
        }
    }
