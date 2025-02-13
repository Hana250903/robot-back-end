using System;
using System.Collections.Generic;

namespace Robot.Repository.Entities;

public partial class Stamp: BaseEntity
{
    public string Type { get; set; }

    public string Size { get; set; }

    public string InkColor { get; set; }

    public virtual ICollection<RobotTask> Tasks { get; set; } = new List<RobotTask>();
}