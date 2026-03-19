using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Payment
{
    public Guid Paymentid { get; set; }

    public Guid? Orderid { get; set; }

    public string? Paymentmethod { get; set; }

    public decimal? Paymentamount { get; set; }

    public DateTime? Paymentdate { get; set; }

    public virtual Order? Order { get; set; }

    public virtual PaymentCard? PaymentCard { get; set; }

    public virtual PaymentVnpay? PaymentVnpay { get; set; }
}
