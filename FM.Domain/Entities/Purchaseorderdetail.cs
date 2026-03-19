using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Purchaseorderdetail
{
    public Guid Purchaseorderdetailid { get; set; }

    public decimal? Importprice { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Subtotal { get; set; }

    public Guid? Productid { get; set; }

    public Guid? Purchaseorderid { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Purchaseorder? Purchaseorder { get; set; }
}
