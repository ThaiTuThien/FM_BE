using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class VSalesReportStore
{
    public string? Storeaddress { get; set; }

    public DateTime? Orderdate { get; set; }

    public decimal? Revenue { get; set; }
}
