﻿using System;
using System.Collections.Generic;

namespace Robot.Repository.Entities;

public partial class RobotTask: BaseEntity
{
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Status { get; set; }

    public int RobotId { get; set; }

    public int? StampId { get; set; }

    public int? ProductId { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual Product Product { get; set; }

    public virtual Robot Robot { get; set; }

    public virtual Stamp Stamp { get; set; }

    public virtual User User { get; set; }
}