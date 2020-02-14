using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LanguagePartner.Services;
using LanguagePartner.Models.DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using LanguagePartner.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace LanguagePartner
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllersWithViews();

            services.AddTransient<FormattingService>();

            services.AddTransient<FeatureToggles>(x => new FeatureToggles
            {   //initialize a new instance of FeatureToggles with the value from configuration (appsetting[.Development].json)
                DeveloperExceptions = configuration.GetValue<bool>("FeatureToggles:DeveloperExceptions")
            });
            
            services.AddDbContext<LearnerDataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LearnerDataContext"));
            });

            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LearnerDataContext"),
                    optionsBuilder =>
                    optionsBuilder.MigrationsAssembly("LanguagePartner"))
            );

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            FeatureToggles features)
        {
            if (features.DeveloperExceptions)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}