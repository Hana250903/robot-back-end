using AutoMapper;
using Robot.Repository.Repositories.Interface;
using Robot.Service.BussinessModels;
using Robot.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Service.Services
{
    public class LogService : ILogService
    {
        private readonly ILogReppository _logRepository;
        private readonly IMapper _mapper;

        public LogService(ILogReppository logReppository, IMapper mapper)
        {
            _logRepository = logReppository;
            _mapper = mapper;
        }

        public Task<LogModel> CreateAsync(LogModel logModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LogModel>> GetAllAsync()
        {
            var list = await _logRepository.GetAllAsync();

            if(!list.Any())
            {
                return null;
            }

            var listLog = list.Select(x => new LogModel
            {
                Id = x.Id,
                Timestamp = x.Timestamp,
                Action = x.Action,
                Details = x.Details,
                TaskId = x.TaskId,
                IsDeleted = x.IsDeleted,
            }).ToList();

            return listLog;
        }

        public Task<LogModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LogModel> UpdateAsync(LogModel logModel, int id)
        {
            throw new NotImplementedException();
        }
    }
}
