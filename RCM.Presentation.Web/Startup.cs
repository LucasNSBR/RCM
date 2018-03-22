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
using RCM.Infra.Data.Context;
using RCM.Infra.Services.Email;
using System;

namespace RCM.Presentation.Web
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
            services.AddMvc();
            services.AddMediatR();
            services.AddDbContext<RCMDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("RCMDatabase")));
            services.AddDbContext<RCMIdentityDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("RCMDatabase")));

            services.AddIdentity<RCMIdentityUser, RCMIdentityRole>(cfg => ConfigureIdentity(cfg))
                .AddEntityFrameworkStores<RCMIdentityDbContext>()
                .AddUserStore<RCMUserStore>()
                .AddUserManager<RCMUserManager>()
                .AddSignInManager<RCMSignInManager>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(cfg =>
                {
                    cfg.ExpireTimeSpan = TimeSpan.FromDays(7);
                    cfg.LoginPath = Configuration["CookieConfiguration:LoginPath"];
                    cfg.LogoutPath = Configuration["CookieConfiguration:LogoutPath"];
                });

            services.AddAuthentication()
                .AddGoogle(cfg =>
                {
                    cfg.ClientId = Configuration["GoogleCredentials:ClientId"];
                    cfg.ClientSecret = Configuration["GoogleCredentials:ClientSecret"];
                });

            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("ActiveUser", p => p.RequireClaim("ActiveUser", "True"));
                cfg.AddPolicy("Admin", p => p.RequireRole("Admin"));
                cfg.AddPolicy("Manager", p => p.RequireRole("Admin", "Manager"));
                cfg.AddPolicy("User", p => p.RequireRole("Admin", "User", "Manager"));
            });

            services.Configure<EmailClientConfiguration>(cfg =>
            {
                cfg.SendGridUser = Configuration["SendGrid:User"];
                cfg.SendGridKey = Configuration["SendGrid:ApiKey"];
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
                    defaults: new { area = "Platform", controller = "Settings", action = "Profile" });

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
            options.SignIn.RequireConfirmedEmail = false;
        }
    }
}
