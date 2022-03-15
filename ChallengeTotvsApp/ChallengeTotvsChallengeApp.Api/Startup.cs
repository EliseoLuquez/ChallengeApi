using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotvsChallengeApp.Application.Interfaces;
using TotvsChallengeApp.Infrastructure.Data;
using TotvsChallengeApp.Infrastructure.Repositories;

namespace ChallengeTotvsChallengeApp.Api
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
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //Dapper
            //services.AddTransient<ITransactionRepository, TransactionRepository>();

            //Usar la implementacion de repository deseada comentando una línea y descomentando la otra
            //Actualmente se usa EF
            services.AddScoped<ITransactionRepository, TransactionRepositoryEF>();


            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TotvsChallengeApp.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Challenge Totvs API {groupName}",
                    Version = groupName,
                    Description = "Endpoints Challenge Totvs API",
                    Contact = new OpenApiContact
                    {
                        Name = "Totvs",
                        Email = string.Empty,
                        Url = new Uri("https://es.totvs.com/"),
                    }
                });
            });
        }
    }
}
