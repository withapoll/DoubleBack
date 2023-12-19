using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DoubleBack.Models;

public partial class Expense
{
    public int Expenseid { get; set; }

    public int? Shopid { get; set; }

    public string Expensename { get; set; } = null!;

    public decimal Amount { get; set; }

    public decimal Price { get; set; }

    public DateOnly ExpensesDate { get; set; }

    [JsonIgnore]
    public virtual Coffeeshop? Shop { get; set; }
}
