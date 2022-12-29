using BigOn.Application.Extensions;
using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.AppCode.Providers;
using BigOn.Domain.AppCode.Services;
using BigOn.Domain.Interfaces.Repositories;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities.Membership;
using BigOn.Domain.Repositories.FakeRepository;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

/*
 fullstackstaff@mail.ru
pwd:   dev-ops-20@2
pv7fBsjEmCwe9jLiswQq
 */

namespace BigOn.WebUI
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(cfg =>
            {
                cfg.ModelBinderProviders.Insert(0, new BooleanBinderProvider());

            });


            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });

            services.AddDbContext<BigOnDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("cString"));
            });

            services.AddIdentity<BigonUser, BigonRole>()
                .AddEntityFrameworkStores<BigOnDbContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<BigonIdentityErrorDescriber>();



            services.AddScoped<UserManager<BigonUser>>();
            services.AddScoped<SignInManager<BigonUser>>();
            services.AddScoped<RoleManager<BigonRole>>();


            services.Configure<AntiforgeryOptions>(cfg =>
            {
                cfg.Cookie.Name = "bigon-ant";
            });

            services.Configure<CryptoServiceOptions>(cfg =>
            {
                configuration.GetSection("cryptograpy").Bind(cfg);
            });
            services.AddSingleton<ICryptoService, CryptoService>();

            services.Configure<EmailServiceOptions>(cfg =>
            {
                configuration.GetSection("emailAccount").Bind(cfg);
            });
            services.AddSingleton<IEmailService, EmailService>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IBrandRepository, FakeBrandRepository>();
            services.AddScoped<IClaimsTransformation, AppClaimProvider>();

            var assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName.StartsWith("BigOn."))
                .ToArray();

            services.AddMediatR(assemblies);
            services.AddAutoMapper(assemblies);

            //https://docs.fluentvalidation.net/en/latest/aspnet.html

            services.AddValidatorsFromAssemblies(assemblies, ServiceLifetime.Singleton);

            services.AddAuthentication(cfg =>
            {
                cfg.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie(cfg =>
                {
                    cfg.Cookie.Name = "bigon";
                    cfg.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    cfg.LoginPath = "/signin.html";
                    cfg.AccessDeniedPath = "/accsesdenied.html";
                });

            services.AddAuthorization(cfg =>
            {

                foreach (string principal in AppClaimProvider.principals)
                {
                    cfg.AddPolicy(principal, p =>
                    {
                        p.RequireAssertion(handler =>
                        {
                            return handler.User.HasAccess(principal);

                        });
                    });
                }
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.SeedMembership();
            app.UseStaticFiles();
            app.UseRouting();


            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(name: "defaultAdmin",
                    areaName: "Admin",
                    pattern: "admin/{controller=home}/{action=index}/{id?}");

                endpoints.MapControllerRoute(name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
