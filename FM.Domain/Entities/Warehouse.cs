using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Warehouse
{
    public Guid Storeid { get; set; }

    public Guid Productid { get; set; }

    public decimal? Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
