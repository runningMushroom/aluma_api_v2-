using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace alumaApi.Extensions
{
    public static class IisExtension
    {
        public static void ConfigureIIS(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }
    }
}