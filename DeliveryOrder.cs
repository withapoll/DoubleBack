using System;
using System.Collections.Generic;

namespace DoubleBack;

public partial class DeliveryOrder
{
    public int Orderid { get; set; }

    public int? Shopid { get; set; }

    public int? Companyid { get; set; }

    public DateOnly Orderdate { get; set; }

    public DateOnly? Deliverydate { get; set; }

    public virtual DeliveryCompany? Company { get; set; }

    public virtual Coffeeshop? Shop { get; set; }
}
