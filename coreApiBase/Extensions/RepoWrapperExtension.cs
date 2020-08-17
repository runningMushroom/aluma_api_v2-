using alumaApi.RepoWrapper;
using Microsoft.Extensions.DependencyInjection;

namespace alumaApi.Extensions
{
    public static class RepoWrapperExtension
    {
        public static void ConfigureRepoWrapper(this IServiceCollection services)
        {
            services.AddScoped<IWrapper, Wrapper>();
        }
    }
}