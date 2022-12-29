using BigOn.Application.Behaviours;
using BigOn.Application.Extensions;
using BigOn.Domain.AppCode.Middlewares;
using BigOn.Domain.AppCode.Providers;
using BigOn.Domain.AppCode.Services;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities.Membership;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;

namespace BigOn.WebApi
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
            services.AddControllers();

            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<UserManager<BigonUser>>();
            services.AddScoped<SignInManager<BigonUser>>();
            services.AddScoped<RoleManager<BigonRole>>();

            services.AddDbContext<BigOnDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("cString"));
            });
            services.AddIdentity<BigonUser, BigonRole>()
                .AddEntityFrameworkStores<BigOnDbContext>()
                .AddErrorDescriber<BigonIdentityErrorDescriber>();


            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["jwt:issuer"],
                    ValidAudience = configuration["jwt:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"])),
                    ClockSkew = TimeSpan.Zero,
                    LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
                    {
                        return expires >= DateTime.UtcNow;
                    }
                };
            });

            services.AddAuthorization(cfg =>
            {
                foreach (var item in AppClaimProvider.principals)
                {
                    cfg.AddPolicy(item, p =>
                    {

                        p.RequireAssertion(handler =>
                        {
                            return handler.User.HasAccess(item);

                        });

                    });
                }
            });

            services.Configure<CryptoServiceOptions>(cfg =>
            {
                configuration.GetSection("cryptograpy").Bind(cfg);
            });
            services.AddSingleton<ICryptoService,CryptoService>();

            services.Configure<EmailServiceOptions>(cfg =>
            {
                configuration.GetSection("emailAccount").Bind(cfg);
            });
            services.AddSingleton<IEmailService, EmailService>();

            services.Configure<TokenServiceOptions>(cfg =>
            {
                configuration.GetSection("jwt").Bind(cfg);
            });
            services.AddSingleton<ITokenService, TokenService>();

            var assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName.StartsWith("BigOn."))
                .ToArray();


            services.AddScoped<IClaimsTransformation,AppClaimProvider>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateBehaviour<,>));

            services.AddMediatR(assemblies);

            //https://docs.fluentvalidation.net/en/latest/aspnet.html

            services.AddValidatorsFromAssemblies(assemblies);

            services.AddAutoMapper(assemblies);

            services.AddCors(cfg => {
                cfg.AddPolicy("allowAll", p =>
                {
                    p.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                    //.WithOrigins("http://localhost:3000", "http://localhost:4200", "http://oxu.az");
                });
            });

            services.AddErrorHandler();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("allowAll");

            app.UseErrorHandler();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllers();
            });
        }
    }
}
