using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using alumaApi.Dto;

namespace alumaApi.Extensions
{
    public static class HangFireExtension
    {
        public static void ConfigureHangfireContext(this IServiceCollection services,
            Microsoft.Extensions.Configuration.IConfiguration config)
        {
            var connections = config.GetSection("ConnectionStrings").Get<ConnectionStringsDto>();
            services.AddHangfire(c => c.UseSqlServerStorage(connections.DefaultConnection));
        }

        public class MyAuthorizationFilter : IDashboardAuthorizationFilter
        {
            public bool Authorize(DashboardContext context)
            {
                var httpContext = context.GetHttpContext();

                // Only authenticated admins should be able to view the
                // hangfire dashboard

                return httpContext.User.Identity.IsAuthenticated &&
                       httpContext.User.Claims.Any(c => c.Value == "Admin") ? true : false;
            }
        }
    }
}