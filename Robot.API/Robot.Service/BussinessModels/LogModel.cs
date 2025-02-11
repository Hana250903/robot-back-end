using Robot.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Service.BussinessModels
{
    public class LogModel: BaseEntity
    {
        public DateTime Timestamp { get; set; }

        public string Action { get; set; }

        public string Details { get; set; }

        public int TaskId { get; set; }

    }
}
