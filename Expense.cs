using System;
using System.Collections.Generic;

namespace DoubleBack;

public partial class Expense
{
    public int Expenseid { get; set; }

    public int? Shopid { get; set; }

    public string Expensename { get; set; } = null!;

    public decimal Amount { get; set; }

    public virtual Coffeeshop? Shop { get; set; }
}
