using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class PaymentCard
{
    public Guid Paymentid { get; set; }

    public string? Cardnumber { get; set; }

    public string? Cardtype { get; set; }

    public virtual Payment Payment { get; set; } = null!;
}
