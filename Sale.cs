using System;
using System.Collections.Generic;

namespace DoubleBack;

public partial class Sale
{
    public int Saleid { get; set; }

    public int? Shopid { get; set; }

    public DateOnly Saledate { get; set; }

    public decimal? Totalsales { get; set; }

    public virtual Coffeeshop? Shop { get; set; }
}
