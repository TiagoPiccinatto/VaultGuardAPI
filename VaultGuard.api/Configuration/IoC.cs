using VaultGuardAPI.Application.Interface.Repository;
using VaultGuardAPI.Application.Interface.Service;
using VaultGuardAPI.Application.Service;
using VaultGuardAPI.Infra.Repository;

namespace VaultGuard.Api.Configuration
{
    public class IoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Base Repository - Base Service
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            //PasswordGenerator
            services.AddScoped<IPasswordGeneratorService, PasswordGeneratorService>();
            services.AddScoped<IPasswordGeneratorRepository, PasswordGeneratorRepository>();
            //Auth
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthUserRepository, AuthUserRepository>();

        }
    }
}
