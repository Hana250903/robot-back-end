﻿using System;
using System.Collections.Generic;

namespace Robot.Repository.Entities;

public partial class Robot: BaseEntity
{
    public string Model { get; set; }

    public string Status { get; set; }

    public string Position { get; set; }

    public DateTime? LastMaintenanceDate { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual ICollection<RobotTask> Tasks { get; set; } = new List<RobotTask>();
}