using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class VSalesReport
{
    public DateTime? Orderdate { get; set; }

    public decimal? Revenue { get; set; }
}
