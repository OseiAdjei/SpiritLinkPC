﻿using System;
using System.Collections.Generic;

namespace SpiritLink.Models;

public partial class FirstTimer
{
    public string FirstTimerName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? GpsAddress { get; set; }

    public string? Status { get; set; }

    public string? Location { get; set; }

    public string WhoInvited { get; set; } = null!;

    public string? AreaDescription { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
