using MCHomem.Senac.PontoWeb.Models;
using MCHomem.Senac.PontoWeb.Models.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;

namespace MCHomem.Senac.PontoWeb.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PontoContext>
                (
                    options => options
                        .UseSqlServer(Configuration.GetConnectionString("DevConnection"))
                );

            // Enable cors to cross origin.
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins
                    (
                        Configuration.GetValue<String>("urlClient")
                        , "http://localhost:65431" // TODO get server info in variables
                    );
                });
            });

            // Config output json to PascalCase.
            services.AddControllers()
                .AddJsonOptions
                (
                    option => option.JsonSerializerOptions.PropertyNamingPolicy = null
                );

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Senac evaluation test - API V1");
            });

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
