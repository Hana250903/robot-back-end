using Robot.Service.BussinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Service.Services.Interface
{
    public interface ILogService
    {
        Task<List<LogModel>> GetAllAsync();
        Task<LogModel> GetByIdAsync(int id);
        Task<LogModel> CreateAsync(LogModel logModel);
        Task<LogModel> UpdateAsync(LogModel logModel, int id);
        Task<int> DeleteAsync(int id);
    }
}
