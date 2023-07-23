using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaultGuardAPI.Application.Interface.Service;
using VaultGuardAPI.Domain.Entities;

namespace VaultGuard.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordGeneratorController : ControllerBase
    {

        private readonly IPasswordGeneratorService _PasswordGeneratorService;
        public PasswordGeneratorController(IPasswordGeneratorService passwordGeneratorService)
        {
            _PasswordGeneratorService = passwordGeneratorService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _PasswordGeneratorService.Get();
           return Ok(res);
        }

        [HttpGet]
        [Authorize]
        public ActionResult<string> GerarSenha(int comprimento, bool incluirMaiusculas, bool incluirMinusculas, bool incluirNumeros, bool incluirCaracteresEspeciais)
        {
            if (comprimento < 9)
            {
                return BadRequest("O comprimento mínimo da senha deve ser de 9 caracteres.");
            }

            int quantidadeTotalTiposCaracteres =
                (incluirMaiusculas ? 1 : 0) +
                (incluirMinusculas ? 1 : 0) +
                (incluirNumeros ? 1 : 0) +
                (incluirCaracteresEspeciais ? 1 : 0);

            if (quantidadeTotalTiposCaracteres == 0)
            {
                return BadRequest("É necessário escolher pelo menos um tipo de caractere para a senha.");
            }
            return _PasswordGeneratorService.GerarSenhaSegura(comprimento, incluirMaiusculas, incluirMinusculas, incluirNumeros, incluirCaracteresEspeciais);
        }



    }

}

