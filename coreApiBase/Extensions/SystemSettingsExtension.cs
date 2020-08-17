using vueBuilderApi.Dto;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace vueBuilderApi.Extensions
{
    public static class SystemSettingsExtension
    {
        public static void ConfigureSystemSettings(this IServiceCollection services,
            Microsoft.Extensions.Configuration.IConfiguration config)
        {
            services.AddSingleton(config.GetSection("SystemSettingsDto").Get<SystemSettingsDto>());
        }
    }
}