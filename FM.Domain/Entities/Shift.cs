using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Shift
{
    public Guid Shiftid { get; set; }

    public DateTime? Starttime { get; set; }

    public DateTime? Endtime { get; set; }

    public Guid? Storeid { get; set; }

    public virtual ICollection<Shiftlog> Shiftlogs { get; set; } = new List<Shiftlog>();

    public virtual Store? Store { get; set; }
}
