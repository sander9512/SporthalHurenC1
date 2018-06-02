using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SporthalHuren.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SporthalHuren.Models.Repository;
using Microsoft.AspNetCore.Session;
using SporthalHuren.Models.Domain_Services;
using SporthalHuren.Models.Persistence.EFRepository;
using Halcyon.Web.HAL.Json;
using Microsoft.AspNetCore.Mvc.Formatters;
using Swashbuckle.AspNetCore.Swagger;

namespace SporthalHuren
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISportshallRepository,
            EFSportsHallRepository>();

            services.AddTransient<IProprietorRepository,
                EFProprietorRepository>();

            services.AddTransient<IUserRepository,
                EFUserRepository>();

            services.AddTransient<IActivityRepository,
                EFActivityRepository>();

            services.AddTransient<IBookingRepository,
                EFBookingRepository>();

            services.AddTransient<IRoomRepository,
                EFRoomRepository>();

            services.AddTransient<IFacilityRepository,
                EFFacilityRepository>();

            services.AddTransient<IOpeningTimeRepository,
                EFOpeningTimeRepository>();

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration["Data:SporthalhurenIdentity:ConnectionString"]));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration["Data:Sporthalhuren:ConnectionString"]));

            // Add framework services.
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Sporthalhuren API", Version = "v1" });
            });
            //.AddMvcOptions(c => {
            //     c.OutputFormatters.RemoveType<JsonOutputFormatter>();
            //     c.OutputFormatters.Add(new JsonHalOutputFormatter(
            //         new string[] { "application/hal+json", "application/vnd.example.hal+json", "application/vnd.example.hal.v1+json" }
            //     ));
            // });
            //.AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // .AddJsonOptions(x => x.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None);

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseIdentity();
            app.UseSession();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            RoleManager.CreateRoles(app).Wait();
            IdentitySeedData.EnsurePopulated(app);
            SeedData.EnsurePopulated(app);
        }
    }
}
