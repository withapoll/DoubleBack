using System;
using System.Collections.Generic;

namespace DoubleBack.Models;

public partial class Human
{
    public int Employeeid { get; set; }

    public string Name { get; set; } = null!;

    public string? Contacts { get; set; }

    public int? Shopid { get; set; }

    public string? Status { get; set; }

    public string? Workaddress { get; set; }

    public decimal? Income { get; set; }

    public virtual Coffeeshop? Shop { get; set; }
}
