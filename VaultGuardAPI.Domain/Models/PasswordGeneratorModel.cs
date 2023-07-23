using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaultGuardAPI.Domain.Models
{
    public class PasswordGeneratorModel
    {
        public Guid Id { get; set; }
        public string SenhaSegura { get; set; } = string.Empty;
        public int Comprimento { get; set; }
        public string CaracteresUsados { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
        public Guid UsuarioId { get; set; }
    }
}

