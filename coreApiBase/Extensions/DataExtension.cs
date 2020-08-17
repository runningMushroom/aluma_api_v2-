using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using vueBuilderApi.Data;
using vueBuilderApi.Dto;

namespace vueBuilderApi.Extensions
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