using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Employee
{
    public Guid Employid { get; set; }

    public string? Employname { get; set; }

    public DateTime? Employbirth { get; set; }

    public string? Employrole { get; set; }

    public string? Employphonenumber { get; set; }

    public DateTime? Employonboarddate { get; set; }

    public Guid? Storeid { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Purchaseorder> Purchaseorders { get; set; } = new List<Purchaseorder>();

    public virtual ICollection<Shiftlog> Shiftlogs { get; set; } = new List<Shiftlog>();

    public virtual Store? Store { get; set; }
}
