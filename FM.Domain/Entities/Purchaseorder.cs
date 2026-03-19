using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Purchaseorder
{
    public Guid Purchaseorderid { get; set; }

    public DateTime? Purchaseorderdate { get; set; }

    public string? Purchaseorderstatus { get; set; }

    public decimal? Totalamount { get; set; }

    public Guid? Storeid { get; set; }

    public Guid? Employid { get; set; }

    public Guid? Supplierid { get; set; }

    public virtual Employee? Employ { get; set; }

    public virtual ICollection<Purchaseorderdetail> Purchaseorderdetails { get; set; } = new List<Purchaseorderdetail>();

    public virtual Purchasepayment? Purchasepayment { get; set; }

    public virtual Store? Store { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
