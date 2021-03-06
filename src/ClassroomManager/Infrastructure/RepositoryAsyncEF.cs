﻿using App.Core.Entities;
using App.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class RepositoryAsyncEF<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        protected readonly ClassroomDbContext _dbContext;

        public RepositoryAsyncEF(ClassroomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
        }

        public virtual async Task<T> GetByUserAsync(string user)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(u => u.User == user);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<long> GetLastIdAsync()
        {
            return await _dbContext.Set<T>().MaxAsync(p => p.Id);
        }
    }
}