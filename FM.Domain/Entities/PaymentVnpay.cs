using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class PaymentVnpay
{
    public Guid Paymentid { get; set; }

    public string? Transactioncode { get; set; }

    public virtual Payment Payment { get; set; } = null!;
}
