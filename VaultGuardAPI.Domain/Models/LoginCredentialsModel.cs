using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaultGuardAPI.Domain.Models
{
    public class LoginCredentialsModel
    {
        public Guid Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool IsAuth { get; set; }
    }
}
