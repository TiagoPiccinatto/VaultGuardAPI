using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VaultGuardAPI.Data.Context;
using VaultGuardAPI.Infra;


namespace VaultGuard.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddControllers();

            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfiles()); });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            IoC.RegisterServices(services);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //services.AddDbContext<VaultGuardContext>(options =>
            //    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<VaultGuardContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }

        public static void UseServices(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
