using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pariplay.API.Extensions;
using Pariplay.DataAccessLayer;
using Pariplay.DataAccessLayer.Abstraction;
using Pariplay.DataAccessLayer.DbContextConfig;

namespace Pariplay.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddScoped(provider =>
                {
                    var configuration = provider.GetService<IConfiguration>();
                    var connectionString = configuration.GetConnectionString("MSSQL");
                    return new PariplayDbContext(connectionString);
                })
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddWorkflows();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pariplay", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pariplay v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
