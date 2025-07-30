using RMS.Bal.Services;
using RMS.Bal.Services.Interfaces;
using RMS.Dal.Repositories;
using RMS.Dal.Repositories.Interfaces;

namespace RMS.Dependency
{
    public static class RmsDependency
    {
        public static IServiceCollection AddRmsDependencies(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IReportService, ReportService>();

            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IReportRepository, ReportRepository>();

            return services;
        }
    }
}
