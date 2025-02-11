﻿using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Robot.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Robot.Repository.Entities;

namespace Robot.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        protected readonly FactoryManagementContext _dbContext;

        public GenericRepository(FactoryManagementContext context)
        {
            _dbSet = context.Set<TEntity>();
            _dbContext = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task SoftDeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }

        public async Task<int> SoftDeleteRangeAsync(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
            }
            _dbSet.UpdateRange(entities);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<int> UpdateRangeAsync(List<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> PermanentDeletedAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> PermanentDeletedListAsync(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _dbSet.Remove(entity);
            }
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task<TEntity?> GetByConditionAsync(Expression<Func<TEntity, bool>> condition)
        {
            var result = await _dbSet.FirstOrDefaultAsync(condition);
            return result;
        }

        public async Task<TEntity?> GetLastInsertedAsync()
        {
            var result = await _dbSet.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            return result;
        }
    }
}
