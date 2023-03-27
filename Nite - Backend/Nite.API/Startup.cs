using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Nite.API.Data;
using Nite.API.Repository;
using Nite.API.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Nite.API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddControllersWithViews()
                    .AddNewtonsoftJson();

            var connectionString = @"Server=localhost,1433;Database=NiteDb;Persist Security Info=False;User ID=sa;Password=Password.1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
            
            services.AddDbContext<DataContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

            services.AddScoped<IServiceModel,ServiceModel>();
            services.AddScoped<ILoginSignupRepository, LoginSignupRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddCors(p => p.AddPolicy("corspolicy", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env) 
        {
            if(env.IsDevelopment()) 
            { 
                app.UseDeveloperExceptionPage();
            }
            else 
            {
                app.UseExceptionHandler("Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("corspolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
