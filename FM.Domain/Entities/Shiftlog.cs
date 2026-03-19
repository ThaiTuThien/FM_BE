using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Shiftlog
{
    public Guid Shiftlogid { get; set; }

    public DateTime? Shiftdate { get; set; }

    public Guid? Shiftid { get; set; }

    public Guid? Employid { get; set; }

    public virtual Employee? Employ { get; set; }

    public virtual Shift? Shift { get; set; }
}
