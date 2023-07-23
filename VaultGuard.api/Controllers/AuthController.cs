using Microsoft.AspNetCore.Mvc;
using VaultGuardAPI.Application.Interface.Service;
using VaultGuardAPI.Domain.Models;

namespace VaultGuard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequestModel model)
        {
            // Verifica as credenciais do usuário
            var autenticado = _authService.VerificarCredenciais(model.Usuario, model.Senha);

            if (!autenticado.IsAuth)
            {
                return Unauthorized("Credenciais inválidas.");
            }

            // Gera o token de autenticação
            string token = _authService.GerarToken(autenticado);

            // Retorna o token no corpo da resposta
            return Ok(new { Token = token });
        }

    }
}
