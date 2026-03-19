using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class VWarehouseStock
{
    public string? Storeaddress { get; set; }

    public string? Productname { get; set; }

    public decimal? Quantity { get; set; }
}
