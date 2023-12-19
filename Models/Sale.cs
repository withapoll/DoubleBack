using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DoubleBack.Models;

public partial class Sale
{
    public int Saleid { get; set; }

    public int? Shopid { get; set; }

    public DateOnly Saledate { get; set; }

    public decimal? Totalsales { get; set; }
    [JsonIgnore]
    public virtual Coffeeshop? Shop { get; set; }
}
