namespace WebApplication1;

using Microsoft.AspNetCore.Authorization;

public class RequireRoleRequirement : IAuthorizationRequirement
{
    public int RequiredRoleId { get; }

    public RequireRoleRequirement(int requiredRoleId)
    {
        Console.WriteLine("required role id ----------------"+requiredRoleId);
        RequiredRoleId = requiredRoleId;
    }
}
