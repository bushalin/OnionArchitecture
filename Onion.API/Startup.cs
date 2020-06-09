using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Onion.API.Middleware;
using Onion.API.Repository;
using Onion.API.Repository.Employee;
using Onion.API.Services.Employee;
using System;

namespace Onion.API
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OnionAPIDbContext>(config =>
            {
                config.UseSqlServer(_config.GetConnectionString("OnionDbAPIConnection"));
            });
            // service to add the http client to the application. without it we can not add an http call
            services.AddHttpClient();

            // for the application to work with any type of controller, we need to add this first
            // we will add newtonsoft json at the end of this
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });



            // this is where we make sure that our application's authentication is form the identityserver4 project.
            // the configure method's(below) authentication is using this authentication service for authenticating the users.
            services.AddAuthentication("Bearer")
                // we need to add the nuget package (Microsoft.AspNetCore.Authentication.JwtBearer) and then add the jwtbearer service to the application
                // to make use of the jwtbearer authentication scheme
                .AddJwtBearer("Bearer", config =>
                {
                    // the authority is where we are going to authenticate our application's user traffic
                    config.Authority = "https://localhost:44367/";

                    // we are introducting our api name to the identity server
                    // name of who we are
                    config.Audience = "basicIdentityApi";
                });

            // using automapper for mapping the properties to the DTOs
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IEmployeeServices, EmployeeServices>();

            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // i have integrated support to Azure and created a new repository in github.
            // have also created a lot of small extensitons in VS2019
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // use this to add authentication. in our case this is identityserver4
            app.UseAuthentication();

            // use this to add authorization. in our case this is identityserver4
            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
