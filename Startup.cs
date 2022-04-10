using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ZehnTech_API_Assessment.DbContextFile;
using ZehnTech_API_Assessment.Extensions;
using ZehnTech_API_Assessment.Interfaces;
using Microsoft.EntityFrameworkCore;
using ZehnTech_API_Assessment.Repositories.Interfaces;
using ZehnTech_API_Assessment.Repositories.Classes;
using ZehnTech_API_Assessment.services;

namespace ZehnTech_API_Assessment
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
            services.AddJwtAuthenticate();
            services.AddControllers();
            services.AddSwagger();
            services.AddDbContext<ZenTechDbContext>(item => item.UseSqlServer(Configuration["ConnectionStrings:MyDB"]));
            services.AddTransient<IAuthenticationManager, services.AuthenticationManager>();
            services.AddTransient<IAuthenticateRepository, AuthenticateRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(swag =>
            {
                swag.SwaggerEndpoint("/swagger/ZehnTechAssessment/swagger.json", "ZehnTech_API");
                swag.RoutePrefix = "swagger";
            });
        }
    }
}
