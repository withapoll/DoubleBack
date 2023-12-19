using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DoubleBack.Models;

public partial class ActiveDelivery
{
    public int Orderid { get; set; }

    public int? Shopid { get; set; }

    public int? Companyid { get; set; }

    public DateOnly? Deliverydate { get; set; }
    [JsonIgnore]
    public virtual DeliveryCompany? Company { get; set; }
    [JsonIgnore]
    public virtual Coffeeshop? Shop { get; set; }
}
