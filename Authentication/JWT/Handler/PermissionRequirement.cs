using Microsoft.AspNetCore.Authorization;

namespace RMS.Authentication.JWT.Handler
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string[] Permissions { get; }
        public PermissionRequirement(params string[] permissions)
        {
            Permissions = permissions;
        }
    }
}
