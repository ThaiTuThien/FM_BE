using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Category
{
    public Guid Categoryid { get; set; }

    public string? Categoryname { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
