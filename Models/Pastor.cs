using System;
using System.Collections.Generic;

namespace SpiritLink.Models;

public partial class Pastor
{
    public string PastorName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public bool? PhoneNumberConfirmed { get; set; }

    public string? Email { get; set; }

    public bool? EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public virtual ICollection<BacentaLeader> BacentaLeaders { get; set; } = new List<BacentaLeader>();

    public virtual ICollection<LaySchool> LaySchools { get; set; } = new List<LaySchool>();

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
