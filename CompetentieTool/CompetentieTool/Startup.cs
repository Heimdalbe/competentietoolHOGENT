using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompetentieTool.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CompetentieTool.Models.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CompetentieTool.Models.IRepositories;
using CompetentieTool.Data.Repositories;

namespace CompetentieTool
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.Stores.MaxLengthForKeys = 128)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddScoped<IVacatureRepository, VacatureRepository>();
            services.AddScoped<ICompetentieRepository, CompetentieRepository>();
            services.AddScoped<IIngevuldeVacatureRepository, IngevuldeVacatureRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthorization(options =>
            {
                options.AddPolicy("OnlyAdminAccess", policy => policy.RequireRole("Admin"));
                options.AddPolicy("OnlyWerkgeverAccess", policy => policy.RequireRole("Admin", "Werkgever"));
                options.AddPolicy("OnlySollicitantAccess", policy => policy.RequireRole("Admin", "Sollicitant"));
            });
        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ApplicationDbContext context, RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //DummyData.Initialize(context, userManager, roleManager).Wait();
        }
        
    }
}
