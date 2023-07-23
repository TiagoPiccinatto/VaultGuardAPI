using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultGuardAPI.Application.Interface.Repository;
using VaultGuardAPI.Application.Interface.Service;
using VaultGuardAPI.Data.Context;
using VaultGuardAPI.Domain.Entities;

namespace VaultGuardAPI.Infra.Repository
{
    public class AuthUserRepository : IAuthUserRepository
    {
        private readonly VaultGuardContext _context;

        public AuthUserRepository(VaultGuardContext context)
        {
            _context = context;
        }

        public UserEntity ObterUsuarioPorNomeUsuario(string nomeUsuario)
        {
            return _context.Users.FirstOrDefault(u => u.NomeUsuario == nomeUsuario);
        }
    }
}
