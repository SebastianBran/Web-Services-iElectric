using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Persistence.Contexts;
using web_services_ielectric.Domain.Repositories;
using web_services_ielectric.Persistence.Repositories;
using web_services_ielectric.Domain.Services;
using web_services_ielectric.Services;

namespace web_services_ielectric
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
            //Add CORS
            services.AddCors();

            services.AddControllers();

            //Database
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 26)));
            });

            //Repositories
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ITechnicianRepository, TechnicianRepository>();
            services.AddScoped<IApplianceModelRepository, ApplianceModelRepository>();
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();

            //Unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ITechnicianService, TechnicianService>();
            services.AddScoped<IApplianceModelService, ApplianceModelService>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();

            //Endpoint Naming Conventions
            services.AddRouting(options => options.LowercaseUrls = true);

            //AutoMapper Setup
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "web_services_ielectric", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "web_services_ielectric v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // CORS Configuration
            app.UseCors(x => x.SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
