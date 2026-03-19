using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Supplier
{
    public Guid Supplierid { get; set; }

    public string? Suppliername { get; set; }

    public string? Supplieraddress { get; set; }

    public string? Supplieremail { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Purchaseorder> Purchaseorders { get; set; } = new List<Purchaseorder>();
}
