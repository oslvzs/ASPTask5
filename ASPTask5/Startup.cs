using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ASPTask5.Services;
using Microsoft.EntityFrameworkCore;
using ASPTask5.Models;
using ASPTask5.Options;

namespace ASPTask5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string connectionString =
           "Server=(localdb)\\mssqllocaldb;"
           + "Database=Students;"
           + "Trusted_Connection=True;"
           + "MultipleActiveResultSets=True;";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CustomOptions>(Configuration);

            services.AddDbContext<StudentContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IService, Service>();
            services.AddScoped<Service>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Student}/{action=Index}/{id?}");
            });
        }
    }
}
