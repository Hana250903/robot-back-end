using System;
using System.Collections.Generic;

namespace Robot.Repository.Entities;

public partial class Maintenance: BaseEntity
{
    public DateTime Date { get; set; }

    public string Technician { get; set; }

    public string Description { get; set; }

    public int RobotId { get; set; }

    public virtual Robot Robot { get; set; }
}