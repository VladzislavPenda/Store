using Contracts;
using Contracts.DataShape;
using Entities;
using Entities.DataTransferObjects.IncludeDTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories;
using Repositories.DataShaping;
using Store.ActionFilters;
using Store.Extensions;
using Store.Server.Extensions;

namespace Store
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSqlContext(Configuration);
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ShopServices>();
            services.ConfigureCors();
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
            services.AddAutoMapper(typeof(Startup), typeof(AutoMapperMarker));
            services.ConfigureResponseCaching();
            services.ConfigureVersioning();
            services.AddControllersWithViews();
            services.ConfigureControllers();
            services.AddMemoryCache();
            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);
            services.AddHttpContextAccessor();
            services.ConfigureSwagger();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseResponseCaching();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Code Maze API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}
