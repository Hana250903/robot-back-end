﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();

    }
}
