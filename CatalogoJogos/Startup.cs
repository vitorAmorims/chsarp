using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogoJogos.Model;
using CatalogoJogos.Repositories;
using CatalogoJogos.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;

namespace CatalogoJogos
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
            services.AddTransient<AppDb>(_ => new AppDb(Configuration["ConnectionStrings:Default"]));
            services.AddScoped<IJogoService, JogoService>();
            services.AddScoped<IGameRepository, GameMySqlRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "CatalogoDeJogosAPI",
                        Description = "A simple example ASP.NET Core Web API",
                        TermsOfService = new Uri("https://example.com/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Vitor Amorim",
                            Email = "vtamorims@gmail.com",
                            Url = new Uri("https://twitter.com/spboyer"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Use under LICX",
                            Url = new Uri("https://example.com/license"),
                        }
                    });
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CatalogoDeJogosAPI");
                    c.RoutePrefix = string.Empty;
                });
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
