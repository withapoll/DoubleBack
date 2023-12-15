using System;
using System.Collections.Generic;

namespace DoubleBack;

public partial class CoffeeStorage
{
    public int Inventoryid { get; set; }

    public int? Shopid { get; set; }

    public string Products { get; set; } = null!;

    public int? Quantity { get; set; }

    public virtual Coffeeshop? Shop { get; set; }
}
