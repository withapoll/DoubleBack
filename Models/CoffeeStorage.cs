using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DoubleBack.Models;

public partial class CoffeeStorage
{
    public int Inventoryid { get; set; }

    public int? Shopid { get; set; }

    public string Products { get; set; } = null!;

    public int? Quantity { get; set; }

    [JsonIgnore]
    public virtual Coffeeshop? Shop { get; set; }
}
