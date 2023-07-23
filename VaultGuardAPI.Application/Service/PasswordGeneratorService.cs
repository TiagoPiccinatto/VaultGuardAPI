using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using VaultGuardAPI.Application.Interface.Repository;
using VaultGuardAPI.Application.Interface.Service;
using VaultGuardAPI.Domain.Entities;

namespace VaultGuardAPI.Application.Service
{
    public class PasswordGeneratorService : BaseService<PasswordGeneratorEntity>, IPasswordGeneratorService
    {
        private readonly IPasswordGeneratorRepository _PasswordGeneratorRepository;

        public PasswordGeneratorService(IBaseRepository<PasswordGeneratorEntity> baseRepository, IMapper mapper, IPasswordGeneratorRepository PasswordGeneratorRepository) : base(baseRepository, mapper)
        {
            _PasswordGeneratorRepository = PasswordGeneratorRepository;
        }

        public string GerarSenhaSegura(int comprimento, bool incluirMaiusculas, bool incluirMinusculas, bool incluirNumeros, bool incluirCaracteresEspeciais)
        {
            string caracteresPermitidos = string.Empty;

            if (incluirMaiusculas)
            {
                caracteresPermitidos += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            if (incluirMinusculas)
            {
                caracteresPermitidos += "abcdefghijklmnopqrstuvwxyz";
            }
            if (incluirNumeros)
            {
                caracteresPermitidos += "0123456789";
            }
            if (incluirCaracteresEspeciais)
            {
                caracteresPermitidos += "!@#$%^&*()-_=+[{]}\\|;:'\",<.>/?";
            }

            Random random = new Random();
            char[] senhaGerada = new char[comprimento];

            for (int i = 0; i < comprimento; i++)
            {
                senhaGerada[i] = caracteresPermitidos[random.Next(caracteresPermitidos.Length)];
            }

            // Embaralha a senha gerada para garantir que a ordem seja aleatória
            for (int i = 0; i < comprimento; i++)
            {
                int randomIndex = random.Next(comprimento);
                char temp = senhaGerada[i];
                senhaGerada[i] = senhaGerada[randomIndex];
                senhaGerada[randomIndex] = temp;
            }

            string senha = new string(senhaGerada);

            // Salva a senha no banco de dados usando o repositório.
            var senhaUsuario = new PasswordGeneratorEntity
            {
                SenhaSegura = senha,
                Comprimento = comprimento,
                CaracteresUsados = caracteresPermitidos,
                DataCriacao = DateTime.Now,
                UsuarioId = new Guid() //todo colocar id usuario logado no sistema
            };

            _PasswordGeneratorRepository.SalvarSenha(senhaUsuario);
            return senha;
        }
    }
}
