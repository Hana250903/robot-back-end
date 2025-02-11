using Robot.Repository.Entities;
using Robot.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Repository.Repositories
{
    public class LogRepository : GenericRepository<Log>, ILogReppository
    {
        private readonly FactoryManagementContext _factoryManagementContext;

        public LogRepository(FactoryManagementContext factoryManagementContext): base(factoryManagementContext)
        {
            _factoryManagementContext = factoryManagementContext;
        }
    }
}
