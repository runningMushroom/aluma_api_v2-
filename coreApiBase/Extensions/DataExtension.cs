using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using alumaApi.Data;
using alumaApi.Dto;

namespace alumaApi.Extensions
{
    public static class DataExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connections = config.GetSection("ConnectionStrings").Get<ConnectionStringsDto>();

            services.AddDbContext<DefaultDbContext>(o => o.UseSqlServer(connections.DefaultConnection));
        }
    }
}