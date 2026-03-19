using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Order
{
    public Guid Orderid { get; set; }

    public DateTime? Orderdate { get; set; }

    public decimal? Ordertotalprice { get; set; }

    public string? Orderpaystatus { get; set; }

    public Guid? Storeid { get; set; }

    public Guid? Employid { get; set; }

    public Guid? Customerid { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employ { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Store? Store { get; set; }
}
