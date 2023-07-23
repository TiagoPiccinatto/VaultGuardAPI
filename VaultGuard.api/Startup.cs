using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using VaultGuard.Api.Configuration;
using VaultGuardAPI.Application;

namespace VaultGuard.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddServices(Configuration, env);

            //string publicKeyPath = "Keys/public_key.pem";

            //// Ler o conteúdo do arquivo public_key.pem
            //string publicKeyContent = File.ReadAllText(publicKeyPath);

            //// Decodificar a chave pública a partir do conteúdo do arquivo
            //using RSA rsa = RSA.Create();
            //rsa.ImportFromPem(publicKeyContent);

            ////Configurar o serviço de autenticação JWT Bearer
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.SaveToken = true;
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new RsaSecurityKey(rsa),
            //            ValidateIssuer = false,
            //            ValidateAudience = false
            //        };
            //    });



            // Configuracao para ler o token gerado e fazer autenticacao 
            byte[] Keys = Encoding.ASCII.GetBytes(SecretKey.Key);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Keys),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

        }

        public void Configure(WebApplication app)
        {
            app.UseServices();
            app.UseRouting();

            // Middleware de autorização
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
