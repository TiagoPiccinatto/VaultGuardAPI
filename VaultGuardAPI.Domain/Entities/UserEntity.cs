using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultGuardAPI.Domain.Entities.Base;

namespace VaultGuardAPI.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        
    }

}
