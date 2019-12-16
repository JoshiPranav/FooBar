using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Rules;
using Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api
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
            services.AddScoped<IFooBarService, FooBarService>();
            services.AddScoped<DivisibilityRuleBase<DivisibleBy15Rule>, DivisibleBy15Rule>();
            services.AddScoped<DivisibilityRuleBase<DivisibleBy5Rule>, DivisibleBy5Rule>();
            services.AddScoped<DivisibilityRuleBase<DivisibleBy3Rule>, DivisibleBy3Rule>();
            services.AddScoped<DivisibilityRuleBase<DivisibleByNoneRule>, DivisibleByNoneRule>();
            services.AddScoped<IFooBarService, FooBarService>();
            services.AddScoped<IFooBarService, FooBarService>();
            services.AddScoped<IFooBarService, FooBarService>();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

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

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
