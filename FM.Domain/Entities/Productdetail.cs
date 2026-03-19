using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class Productdetail
{
    public Guid Productdetail1 { get; set; }

    public decimal? Productprice { get; set; }

    public Guid? Productid { get; set; }

    public virtual Product? Product { get; set; }
}
