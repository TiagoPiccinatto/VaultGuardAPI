using Microsoft.AspNetCore.Mvc;
using VaultGuardAPI.Domain.Entities;

namespace VaultGuard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        //    [HttpPost]
        //    public async Task<ActionResult<UserEntity>> CriarUsuario([FromForm] UserEntity usuario)
        //    {
        //        try
        //        {
        //            // Chame o serviço para criar o usuário
        //            var novoUsuario = await _usuarioService.CriarUsuarioAsync(usuario);

        //            return Ok(novoUsuario); // Retornar o usuário criado com sucesso
        //        }
        //        catch (Exception ex)
        //        {
        //            // Tratar possíveis exceções, como erro de validação, falha no banco de dados, etc.
        //            return BadRequest($"Erro ao criar usuário: {ex.Message}");
        //        }
        //    }
        //}
    }
}
