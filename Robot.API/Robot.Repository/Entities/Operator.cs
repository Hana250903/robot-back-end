﻿using System;
using System.Collections.Generic;

namespace Robot.Repository.Entities;

public partial class Operator: BaseEntity
{
    public string Name { get; set; }

    public string Shift { get; set; }

    public string ContactInfo { get; set; }
}