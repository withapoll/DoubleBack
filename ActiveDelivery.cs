using System;
using System.Collections.Generic;
using DoubleBack.Models;

namespace DoubleBack;

public partial class ActiveDelivery
{
    public int Orderid { get; set; }

    public int? Shopid { get; set; }

    public int? Companyid { get; set; }

    public DateOnly? Deliverydate { get; set; }

    public virtual DeliveryCompany? Company { get; set; }

    public virtual Coffeeshop? Shop { get; set; }
}
