using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RCM.CrossCutting.Identity.Context;
using RCM.CrossCutting.Identity.Models;
using RCM.CrossCutting.IoC;
using RCM.Infra.Models;
using System;

namespace RCM.Presentation.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMediatR();
            services.AddDbContext<RCMDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("RCMDatabase")));
            services.AddDbContext<RCMIdentityDbContext>();

            services.AddIdentity<RCMIdentityUser, RCMIdentityRole>(cfg =>
                {
                    ConfigureIdentity(cfg);
                })
                .AddEntityFrameworkStores<RCMIdentityDbContext>()
                .AddUserStore<RCMUserStore>()
                .AddUserManager<RCMUserManager>()
                .AddSignInManager<RCMSignInManager>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(cfg =>
                {
                    cfg.ExpireTimeSpan = TimeSpan.FromDays(7);
                    cfg.LoginPath = "/Accounts/Login";
                    cfg.LogoutPath = "/Accounts/Logout";
                });

            services.AddAuthentication()
                .AddGoogle(cfg =>
                {
                    cfg.ClientId = "822877628478-r9in69b6dnqilsc7vd96bfd79jcqmef4.apps.googleusercontent.com";
                    cfg.ClientSecret = "Jj3JhVJS3WTVBc6goYAB8lAy";
                });

            Bootstrapper.RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "accounts",
                    template: "Accounts/",
                    defaults: new { controller = "Accounts", action = "Login" });

                routes.MapRoute(
                    name: "platform",
                    template: "Platform/",
                    defaults: new { area = "Platform", controller = "Duplicatas", action = "Index" });

                routes.MapRoute(
                    name: "manage",
                    template: "Platform/Manage/",
                    defaults: new { area = "Platform", controller = "Manage", action = "Settings" });

                routes.MapRoute(
                     name: "areas",
                     template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureIdentity(IdentityOptions options)
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;

            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;

            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";

            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedEmail = true;
        }
    }
}
