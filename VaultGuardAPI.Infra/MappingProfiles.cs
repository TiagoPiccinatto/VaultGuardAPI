using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultGuardAPI.Domain.Entities;
using VaultGuardAPI.Domain.Models;

namespace VaultGuardAPI.Infra
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PasswordGeneratorEntity, PasswordGeneratorModel>().ReverseMap();
        }
    }
}
