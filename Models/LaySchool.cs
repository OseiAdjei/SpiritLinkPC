using System;
using System.Collections.Generic;

namespace SpiritLink.Models;

public partial class LaySchool
{
    public string SchoolName { get; set; } = null!;

    public string SchoolId { get; set; } = null!;

    public string PastorName { get; set; } = null!;

    public string MemberName { get; set; } = null!;

    public string ConvertName { get; set; } = null!;

    public string FirstTimerName { get; set; } = null!;

    public int LeaderId { get; set; }

    public string LeaderName { get; set; } = null!;

    public string? MemberId { get; set; }

    public string? Date { get; set; }

    public virtual BacentaLeader BacentaLeader { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;

    public virtual Pastor PastorNameNavigation { get; set; } = null!;
}
