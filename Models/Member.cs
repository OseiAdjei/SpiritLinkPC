using System;
using System.Collections.Generic;

namespace SpiritLink.Models;

public partial class Member
{
    public string MemberName { get; set; } = null!;

    public string PastorName { get; set; } = null!;

    public string ConvertName { get; set; } = null!;

    public string FirstTimerName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public bool? ActiveStatus { get; set; }

    public string? Gpsaddress { get; set; }

    public string? Basonta { get; set; }

    public string? Location { get; set; }

    public string? AreaDescription { get; set; }

    public virtual NewConvert ConvertNameNavigation { get; set; } = null!;

    public virtual FirstTimer FirstTimerNameNavigation { get; set; } = null!;

    public virtual ICollection<LaySchool> LaySchools { get; set; } = new List<LaySchool>();

    public virtual Pastor PastorNameNavigation { get; set; } = null!;
}
