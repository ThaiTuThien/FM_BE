using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Purchasepayment
{
    public Guid Paymentid { get; set; }

    public Guid? Purchaseorderid { get; set; }

    public string? Paymentmethod { get; set; }

    public decimal? Paymentamount { get; set; }

    public DateTime? Paymentdate { get; set; }

    public virtual Purchaseorder? Purchaseorder { get; set; }
}
