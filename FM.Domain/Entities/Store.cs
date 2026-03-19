using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Store
{
    public Guid Storeid { get; set; }

    public string? Storeaddress { get; set; }

    public string? Storecontactinfo { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Purchaseorder> Purchaseorders { get; set; } = new List<Purchaseorder>();

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
