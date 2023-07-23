using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultGuardAPI.Application.Interface.Repository;
using VaultGuardAPI.Data.Context;
using VaultGuardAPI.Domain.Entities;

namespace VaultGuardAPI.Infra.Repository
{
    public class PasswordGeneratorRepository : BaseRepository<PasswordGeneratorEntity>, IPasswordGeneratorRepository
    {
        public PasswordGeneratorRepository(VaultGuardContext context) : base(context)
        {
        }
        public void SalvarSenha(PasswordGeneratorEntity UserPassWord)
        {
            _context.PasswordGenerator.Add(UserPassWord);
            _context.SaveChanges();
        }
    }
}
