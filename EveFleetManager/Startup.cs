using ESI.NET;
using EveFleetManager.Controllers;
using EveFleetManager.Controllers.Interfaces;
using EveFleetManager.DataContext;
using EveFleetManager.Models;
using EveFleetManager.Services;
using EveFleetManager.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace EveFleetManager
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddAzureAppConfiguration(System.Environment.GetEnvironmentVariable("AzureAppConfig"));
            Environment = env;
            Configuration = builder.Build();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var EsiConfig = Configuration.GetSection("EsiConfig");
            EsiConfig["ClientId"] = Configuration["ESIConfigClientId"];
            EsiConfig["SecretKey"] = Configuration["ESIConfigSecretKey"];
            EsiConfig["CallbackUrl"] = Configuration["ESIConfigCallbackUrl"];
            EsiConfig["UserAgent"] = Configuration["ESIConfigUserAgent"];
            services.AddEsi(EsiConfig);

            var a = EsiConfig["ClientId"];
            var b = EsiConfig["SecretKey"];
            var c = EsiConfig["CallbackUrl"];
            var d = EsiConfig["UserAgent"];

            services.AddDbContext<EveFleetManagerContext>(options =>
                options.UseSqlServer(Configuration["EFMDBConnectionString"]));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<EsiAuthScopesModel>(Configuration.GetSection("EsiAuthScopes"));
            

            //Controllers
            services.AddScoped<IAuthController, AuthController>();

            //Services
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<ISessionService, SessionService>();

            //Respoitories


            //Helpers


            //Singletons
            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
