using PaymentApp.Infrastructure.EntityFramework.Context;
using PaymentApp.Infrastructure.EntityFramework.Seeder;
using PaymentApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;

namespace PaymentApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        readonly AppServiceSetup appServiceSetup;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            appServiceSetup = new AppServiceSetup();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
            });

            appServiceSetup.Set(services, Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "V1" });
              
            });

            services.AddTransient<Seeder>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy("myLocal",
                    policy => policy.AllowAnyOrigin()
                                  //.WithOrigins("http://localhost:4200")
                                    .AllowAnyMethod()
                                    .WithExposedHeaders("content-disposition")
                                    .AllowAnyHeader()
                                    .AllowCredentials());
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
            });

            app.UseCors("myLocal");

            app.UseMvc();
        }
    }
}
