using BookManagementAPI.Contracts;
using BookManagementAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Text.Json;

namespace BookManagementAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookManagementAPI", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddDbContext<RepositoryDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LocalConnection"));
            });

            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Error middleware
            app.Use(async (httpContext, next) =>
            {
                try
                {
                    await next();
                } 
                catch (Exception ex)
                {
                    httpContext.Response.ContentType = "application/json";
                    httpContext.Response.StatusCode = 500;

                    object response;

                    if(env.IsDevelopment())
                    {
                        response = new { Message = ex.Message, StatusCode = 500, Details = ex.StackTrace };
                    }
                    else
                    {
                        response = new { Message = ex.Message, StatusCode = 500 };
                    }
                    var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    
                    await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, options));
                }
            });

            

            if (env.IsDevelopment())
            {
                
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookManagementAPI v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}