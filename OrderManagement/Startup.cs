using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OM.Application;
using OM.Application.Common.Mappings;
using OM.Application.Interfaces;
using OM.Infrastructure;
using OrderManagement.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OrderManagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(opts =>
            {
                opts.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                opts.AddProfile(new AssemblyMappingProfile(typeof(IOrdersDbContext).Assembly));
            });

            services.AddApplication();
            services.AddInfrastructure(Configuration);
            //services.AddControllers();
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<OperationCancelledExceptionFilter>();
            }).AddRazorRuntimeCompilation();

            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            services.AddCors(opts =>
            {
                opts.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
