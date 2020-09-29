using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Moral.Api.Constants;
using Moral.Api.Context;
using Moral.Api.Entities;
using Moral.Api.Ext;
using Moral.Api.Infrastructure;
using Moral.Api.Services;

namespace Moral.Api
{
    public class Startup
    {
        private const string ApiName = "Sample ASP.Net Core JWT API";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<MoralContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<Account, IdentityRole>()
                .AddEntityFrameworkStores<MoralContext>()
                .AddDefaultTokenProviders();

            services.AddJwtBearerAuthentication(
                Configuration["Authentication:TokenSigningKey"],
                Configuration["Authentication:Issuer"],
                Configuration["Authentication:Audience"],
                60,
                1440);

            ConfigureAuthorizationPolicies(services);

            services.AddTransient<UserManager<Account>>();
            services.AddTransient<UserManager>();
            services.AddSwaggerDocumentation();
            services.AddTransient<IEmailSender, K1EmailSender>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddHttpContextAccessor();
        }
        private static void ConfigureAuthorizationPolicies(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(ClaimPolicies.OwnUser, policy =>
                {
                    policy.Requirements.Add(new OwnUserRequirement());
                });
            });

            services.AddSingleton<IAuthorizationHandler, OwnUserHandler>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
