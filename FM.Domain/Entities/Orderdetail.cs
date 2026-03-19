using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Orderdetail
{
    public Guid Orderdetailid { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Unitprice { get; set; }

    public decimal? Subtotal { get; set; }

    public Guid? Orderid { get; set; }

    public Guid? Productid { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
