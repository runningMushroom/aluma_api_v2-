using AutoMapper;
using vueBuilderApi.Extensions;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace vueBuilderApi
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("appsettings.Development.json")
                    .Build();
            else
                Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("appsettings.Production.json")
                    .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureIIS();
            services.ConfigureJwtAuthentication(Configuration);
            services.ConfigureSqlContext(Configuration);
            services.ConfigureRepoWrapper();
            services.AddAutoMapper(typeof(Startup));
            services.ConfigureHangfireContext(Configuration);
            services.ConfigureSystemSettings(Configuration);
            services.AddControllers()
                .AddJsonOptions(c =>
                {
                    c.JsonSerializerOptions.MaxDepth = 0;
                    c.JsonSerializerOptions.AllowTrailingCommas = true;
                    c.JsonSerializerOptions.WriteIndented = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseHangfireDashboard();
            }
            else
            {
                app.UseHangfireDashboard("/hangfire", new DashboardOptions
                {
                    Authorization = new[] { new HangFireExtension.MyAuthorizationFilter() }
                });
            }

            app.UseHangfireServer();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}