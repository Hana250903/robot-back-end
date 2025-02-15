﻿using System;
using System.Collections.Generic;

namespace Robot.Repository.Entities;

public partial class Product: BaseEntity
{
    public string Name { get; set; }

    public string Dimensions { get; set; }

    public string Material { get; set; }

    public virtual ICollection<RobotTask> Tasks { get; set; } = new List<RobotTask>();
}