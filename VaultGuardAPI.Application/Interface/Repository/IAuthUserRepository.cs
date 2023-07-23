using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultGuardAPI.Domain.Entities;

namespace VaultGuardAPI.Application.Interface.Repository
{
    public interface IAuthUserRepository
    {
        UserEntity ObterUsuarioPorNomeUsuario(string nomeUsuario);
    }
}
