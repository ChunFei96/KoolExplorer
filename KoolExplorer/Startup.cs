using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Configuration;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Services.Dashboard;
using Services.DropDown;
using Services.Filter;
using Services.GovAPI;
using Services.Login;
using Services.Parent;
using Services.Register;
using Services.Operator;

namespace KoolExplorer
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
            services.AddScoped<IGovAPIService, GovAPIService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IParentService, ParentService>();
            services.AddScoped<IDropDownService, DropDownService>();
            services.AddScoped<IFilterService, FilterService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IOperatorService, OperatorService>();

            services.AddDbContext<EFDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(Startup));

            services.Configure<GovAPIURLConfig>(Configuration.GetSection("Gov_API"));

            // configure password settings
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<EFDbContext>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Or you can also register as follows

            services.AddHttpContextAccessor();

            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            services.AddControllersWithViews(); //Allow API calls 
            services.AddRazorPages().AddRazorRuntimeCompilation();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); //Allow API Controller to be called
                endpoints.MapRazorPages();
            });
        }
    }
}
