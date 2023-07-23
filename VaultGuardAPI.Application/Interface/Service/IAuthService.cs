using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultGuardAPI.Domain.Models;

namespace VaultGuardAPI.Application.Interface.Service
{
    public interface IAuthService
    {
        LoginCredentialsModel VerificarCredenciais(string nomeUsuario, string senha);
        string GerarToken(LoginCredentialsModel loginCredentials);
    }

}
