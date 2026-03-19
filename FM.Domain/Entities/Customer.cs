using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Customer
{
    public Guid Customerid { get; set; }

    public byte[]? Customername { get; set; }

    public byte[]? Customerphonenumber { get; set; }

    public byte[]? Customeremail { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
