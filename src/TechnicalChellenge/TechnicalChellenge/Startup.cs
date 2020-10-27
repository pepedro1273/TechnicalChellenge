using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Services.Implementations;
using Services.Interfaces;

namespace TechnicalChellenge
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
            services.AddControllers();

            #region Services

            services.AddScoped<IDecomposeNumberService, DecomposeNumberService>();

            #endregion

            services.AddControllers()
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                    .AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Localiza | Technical Chellenge Api",
                        Version = "v1",
                        Description = "Technical Chellenge Api",
                        Contact = new OpenApiContact
                        {
                            Name = "Localiza",
                            Url = new Uri("https://localhost:5001")
                        }
                    });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region Swagger
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "help/{documentName}/docs.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{string.Empty}/help/v1/docs.json", "Localiza Api");
                c.RoutePrefix = "help";
            });

            #endregion
        }
    }
}
