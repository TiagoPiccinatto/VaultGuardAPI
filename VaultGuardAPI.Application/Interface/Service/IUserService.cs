using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultGuardAPI.Domain.Entities;

namespace VaultGuardAPI.Application.Interface.Service
{
    public interface IUsuarioService
    {
        Task<UserEntity> CriarUsuarioAsync(UserEntity usuario);
    }
}
