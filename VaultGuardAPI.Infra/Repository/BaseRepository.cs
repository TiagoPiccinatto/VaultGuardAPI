﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultGuardAPI.Application.Interface.Repository;
using VaultGuardAPI.Data.Context;
using VaultGuardAPI.Domain.Entities.Base;

namespace VaultGuardAPI.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected VaultGuardContext _context;
        public BaseRepository(VaultGuardContext context)
        {
            _context = context;
        }

        public bool Delete(Guid id)
        {
            var result = _context.Set<T>().Find(id);

            if (result != null)
            {
                _context.Set<T>().Remove(result);
                _context.Entry(result).State = EntityState.Deleted;

                return Convert.ToBoolean(_context.SaveChanges());
            }
            return false;
        }

        public bool Insert(T obj)
        {
            _context.Set<T>().Attach(obj);
            _context.Entry(obj).State = EntityState.Added;

            return Convert.ToBoolean(_context.SaveChanges());
        }

        public T? Select(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> SelectAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public bool Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return Convert.ToBoolean(_context.SaveChanges());
        }
    }
}
