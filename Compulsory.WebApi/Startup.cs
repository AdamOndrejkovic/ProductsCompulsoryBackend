using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compulsory.Core.IServices;
using Compulsory.Core.Models;
using Compulsory.Domain.IRepository;
using Compulsory.Domain.Services;
using Compulsory.Infrastructure;
using Compulsory.Infrastructure.Repositories;
using Compulsory.Security;
using Compulsory.Security.Authenticator;
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

namespace Compulsory.WebApi
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Compulsory.WebApi", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("dev-cors", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            
            services.AddDbContext<CompulsoryContext>(
                opt =>
                {
                    opt.UseLoggerFactory(loggerFactory)
                        .UseSqlite("Data Source=petShop.db");
                }, ServiceLifetime.Transient
            );
            
            services.AddScoped<IAdminService,AdminService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<IAdminRepository,AdminRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            
            services.AddScoped<IAuthenticationHelper,AuthenticationHelper>();
            services.AddScoped<IAuthenticator, Authenticator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Compulsory.WebApi v1"));
                app.UseCors("dev-cors");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}