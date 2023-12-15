using System;
using System.Collections.Generic;

namespace DoubleBack;

public partial class UsersAuthentication
{
    public int Userid { get; set; }

    public int? Shopid { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? Accesslevel { get; set; }

    public virtual Coffeeshop? Shop { get; set; }
}
