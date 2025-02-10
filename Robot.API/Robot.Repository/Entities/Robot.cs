﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Robot.Repository.Entities;

public partial class Robot
{
    public int RobotId { get; set; }

    public string Model { get; set; }

    public string Status { get; set; }

    public string Position { get; set; }

    public DateTime? LastMaintenanceDate { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}