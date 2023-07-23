using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VaultGuardAPI.Application.Interface.Repository;
using VaultGuardAPI.Application.Interface.Service;
using VaultGuardAPI.Domain.Models;

namespace VaultGuardAPI.Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthUserRepository _userRepository;
        //private readonly string _privateKeyPath = $@"Keys/private_key.pem"; // Caminho para a chave privada
        //private readonly string _publicKeyPath = $@"Keys/public_key.pem";   // Caminho para a chave pública

        public AuthService(IAuthUserRepository usuarioRepository)
        {
            _userRepository = usuarioRepository;
        }

        public LoginCredentialsModel VerificarCredenciais(string nomeUsuario, string senha)
        {
            var LoginCredentialsModel = new LoginCredentialsModel();
            // Obtém o usuário pelo nome de usuário
            var usuario = _userRepository.ObterUsuarioPorNomeUsuario(nomeUsuario);
            if (usuario != null) 
            {
                 LoginCredentialsModel = new LoginCredentialsModel
                {
                    Id = usuario.Id,
                    Usuario = nomeUsuario,
                    Senha = senha                  
                };
            }
            
            // Verifica se o usuário foi encontrado e se a senha está correta
            if (usuario != null && usuario.Senha == senha)
            {
                LoginCredentialsModel.IsAuth = true;
                return LoginCredentialsModel;
            }

            LoginCredentialsModel.IsAuth = false;
            return LoginCredentialsModel;
        }



        //public string GerarToken(LoginCredentialsModel loginCredentials)
        //{
        //    var privateKey = new RSACryptoServiceProvider();
        //    privateKey.ImportFromPem(File.ReadAllText(_privateKeyPath));

        //    var claims = new[]
        //    {
        //    // Aqui você pode adicionar outras claims como, por exemplo, o papel (role) do usuário
        //    new Claim(ClaimTypes.Name, loginCredentials.Usuario),
        //    new Claim(ClaimTypes.NameIdentifier, loginCredentials.Id.ToString())
        //    };

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.UtcNow.AddHours(1), // Tempo de expiração do token (1 hora neste exemplo)
        //        SigningCredentials = new SigningCredentials(new RsaSecurityKey(privateKey), SecurityAlgorithms.RsaSha256Signature)
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var tokenString = tokenHandler.WriteToken(token);

        //    return tokenString;
        //}

        public string GerarToken(LoginCredentialsModel loginCredentials)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretKey.Key);

            var claims = new[]
            {
            // Aqui você pode adicionar outras claims como, por exemplo, o papel (role) do usuário
            new Claim(ClaimTypes.Name, loginCredentials.Usuario),
            new Claim(ClaimTypes.NameIdentifier, loginCredentials.Id.ToString())
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1), // Tempo de expiração do token (1 hora neste exemplo)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
