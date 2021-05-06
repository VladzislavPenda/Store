using AspNetCoreRateLimit;
using AutoMapper;
using Contracts;
using Contracts.DataShape;
using Entities.AutoMappers;
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

namespace Store
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataShaper<ModelFullInfo>, DataShaper<ModelFullInfo>>();
            services.ConfigureSqlContext(Configuration);
            services.AddScoped<ValidationFilterAttribute>();
            services.ConfigureCors();
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile());});
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            //services.ConfigureResponseCaching();
            //services.ConfigureHttpCacheHeaders();
            services.ConfigureVersioning();
            services.ConfigureControllerWithViews();
            //services.AddMemoryCache();
            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);
            services.ConfigureRateLimitingOptions();
            services.AddHttpContextAccessor();
            services.ConfigureSwagger();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            //app.UseResponseCaching();
            //app.UseHttpCacheHeaders();
            app.UseIpRateLimiting();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Code Maze API v1");
                //s.SwaggerEndpoint("/swagger/v2/swagger.json", "Code Maze API v2");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            
        }
    }
}
