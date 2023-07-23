using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultGuardAPI.Domain.Entities;

namespace VaultGuardAPI.Data.Context
{
    public class VaultGuardContext : DbContext
    {
        public VaultGuardContext(DbContextOptions<VaultGuardContext> options) : base(options)
        {

        }
        public DbSet<PasswordGeneratorEntity> PasswordGenerator => Set<PasswordGeneratorEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();

    }
}
