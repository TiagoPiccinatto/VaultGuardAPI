using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultGuardAPI.Domain.Entities;

namespace VaultGuardAPI.Application.Interface.Service
{
    public interface IPasswordGeneratorService : IBaseService<PasswordGeneratorEntity>
    {
        string GerarSenhaSegura(int comprimento, bool incluirMaiusculas, bool incluirMinusculas, bool incluirNumeros, bool incluirCaracteresEspeciais);
    }
}
