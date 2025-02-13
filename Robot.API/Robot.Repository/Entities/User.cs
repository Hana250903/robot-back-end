using Robot.Repository.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robot.Repository.Entities
{
    public partial class User: BaseEntity
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? CodeOTPEmail { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<RobotTask> Tasks { get; set; } = new List<RobotTask>();
    }
}
