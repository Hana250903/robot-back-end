﻿using System;
using System.Collections.Generic;

namespace Robot.Repository.Entities;

public partial class Log: BaseEntity
{
    public DateTime Timestamp { get; set; }

    public string Action { get; set; }

    public string Details { get; set; }

    public int TaskId { get; set; }

    public virtual RobotTask Task { get; set; }
}