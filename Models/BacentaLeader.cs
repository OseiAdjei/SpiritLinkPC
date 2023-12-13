using System;
using System.Collections.Generic;

namespace SpiritLink.Models;

public partial class BacentaLeader
{
    public string LeaderName { get; set; } = null!;

    public int LeaderId { get; set; }

    public string PastorName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public bool? PhoneNumberConfirmed { get; set; }

    public string? Email { get; set; }

    public bool? EmailConfirmed { get; set; }

    public virtual ICollection<LaySchool> LaySchools { get; set; } = new List<LaySchool>();

    public virtual Pastor PastorNameNavigation { get; set; } = null!;
}
