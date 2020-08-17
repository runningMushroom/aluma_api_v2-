using vueBuilderApi.RepoWrapper;
using Microsoft.Extensions.DependencyInjection;

namespace vueBuilderApi.Extensions
{
    public static class RepoWrapperExtension
    {
        public static void ConfigureRepoWrapper(this IServiceCollection services)
        {
            services.AddScoped<IWrapper, Wrapper>();
        }
    }
}