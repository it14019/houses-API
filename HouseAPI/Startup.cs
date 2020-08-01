using AutoMapper;
using HouseAPI.Domain.Models;
using HouseAPI.Domain.Repositories;
using HouseAPI.Domain.Services;
using HouseAPI.Persistance.Contexts;
using HouseAPI.Persistance.Repositories;
using HouseAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HouseAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("house-api-in-memory");
            });

            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IResidentRepository, ResidentRespository>();

            services.AddScoped<IHouseService, HouseService>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IResidentService, ResidentService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(House));
            services.AddAutoMapper(typeof(Apartment));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
