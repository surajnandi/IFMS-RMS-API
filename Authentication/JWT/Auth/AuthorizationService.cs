using Microsoft.AspNetCore.Authorization;
using RMS.Authentication.JWT.Handler;

namespace RMS.Authentication.JWT.Auth
{
    public static class AuthorizationService
    {
        public static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            // Register custom authorization handler
            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

            // Add authorization policies
            services.AddAuthorization(options =>
            {
                #region policy
                options.AddPolicy("all-permission", policy =>
                    policy.Requirements.Add(new PermissionRequirement("all-permission")));

                options.AddPolicy("approver", policy =>
                    policy.RequireRole("approver"));

                options.AddPolicy("operator", policy =>
                    policy.RequireRole("operator"));

                options.AddPolicy("can-view-report", policy =>
                {
                    policy.RequireRole("approver", "operator");
                    policy.Requirements.Add(new PermissionRequirement("can-view-report"));
                });

                // Do Not Allow Permission
                options.AddPolicy("DoNotAllow", policy => policy.RequireAssertion(_ => false));
                #endregion
            });
        }
    }
}
