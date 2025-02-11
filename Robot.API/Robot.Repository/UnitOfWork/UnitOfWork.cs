using Microsoft.EntityFrameworkCore.Storage;
using Robot.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FactoryManagementContext _factoryManagementContext;
        private IDbContextTransaction? _transaction = null;

        public UnitOfWork(FactoryManagementContext cursusContext)
        {
            _factoryManagementContext = cursusContext;
        }
        public async Task BeginTransactionAsync()
        {
            _transaction = await _factoryManagementContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }

        public void Dispose()
        {
            _factoryManagementContext.Dispose(); // Giải phóng tài nguyên quản lý
            GC.SuppressFinalize(this); // Garbage Collector không cần thực thi phương thức hủy nữa
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task<int> SaveChanges()
        {
            return await _factoryManagementContext.SaveChangesAsync();
        }
    }
}
