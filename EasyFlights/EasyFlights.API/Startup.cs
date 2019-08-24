using EasyFlights.API.Repositories;
using EasyFlights.API.Services;
using EasyFlights.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;

namespace EasyFlights.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost:5001", "https://localhost:5000"));
            });


            services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("Users"));
            services.AddDbContext<TicketContext>(opt => opt.UseInMemoryDatabase("Tickets"));


            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IDepartureTRepository, DepartureTRepository>();
            services.AddScoped<IBonusPRepository, BonusPRepository>();

            services.AddScoped<IDataService, DataService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "Documentation for the easyflights web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Kevin Scheyltjens",
                        Email = string.Empty
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseCors(options => options.WithOrigins("https://localhost:5001", "https://localhost:5000"));
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
