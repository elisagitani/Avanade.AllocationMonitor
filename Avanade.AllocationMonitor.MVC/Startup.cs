using Avanade.AllocationMonitor.Core.BusinessLayers;
using Avanade.AllocationMonitor.Core.DependencyContainers;
using Avanade.AllocationMonitor.Core.Mocks.Repositories;
using Avanade.AllocationMonitor.Core.Mocks.Storages;
using Avanade.AllocationMonitor.Core.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.MVC
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
            services.AddControllersWithViews();

            DependencyContainer.Register<MainBusinessLayer, MainBusinessLayer>();
            DependencyContainer.Register<AuthenticationBusinessLayer,AuthenticationBusinessLayer>();
          
            DependencyContainer.Register<IAssegnazioneRepository,InMemoryAssegnazioneRepository>();
            DependencyContainer.Register<IAttivitaRepository,InMemoryAttivitaRepository>();
            DependencyContainer.Register<IClienteRepository,InMemoryClienteRepository>();
            DependencyContainer.Register<IDipendenteRepository,InMemoryDipendenteRepository>();
            DependencyContainer.Register<IMansioneRepository,InMemoryMansioneRepository>();
            DependencyContainer.Register<ICommessaRepository, InMemoryCommessaRepository>();
            DependencyContainer.Register<ITimesheetRepository, InMemoryTimesheetRepository>();
            DependencyContainer.Register<IUserRepository, InMemoryUserRepository>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("True"));
                options.AddPolicy("User", policy => policy.RequireRole("False"));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                    option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Forbidden");
                });

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

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Login}/{id?}");
            });
        }
    }
}
