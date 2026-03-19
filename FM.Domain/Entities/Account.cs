using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Account
{
    public Guid Accountid { get; set; }

    public string Username { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public Guid? Employid { get; set; }

    public virtual Employee? Employ { get; set; }
}
