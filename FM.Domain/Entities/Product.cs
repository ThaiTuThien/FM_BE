using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Product
{
    public Guid Productid { get; set; }

    public string? Productname { get; set; }

    public Guid? Categoryid { get; set; }

    public Guid? Supplierid { get; set; }

    public string? Prodes { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<Productdetail> Productdetails { get; set; } = new List<Productdetail>();

    public virtual ICollection<Purchaseorderdetail> Purchaseorderdetails { get; set; } = new List<Purchaseorderdetail>();

    public virtual Supplier? Supplier { get; set; }

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
