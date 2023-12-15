using System;
using System.Collections.Generic;

namespace DoubleBack;

public partial class DeliveryCompany
{
    public int Companyid { get; set; }

    public string Companyname { get; set; } = null!;

    public string? Contactinfo { get; set; }

    public virtual ICollection<ActiveDelivery> ActiveDeliveries { get; set; } = new List<ActiveDelivery>();

    public virtual ICollection<DeliveryOrder> DeliveryOrders { get; set; } = new List<DeliveryOrder>();
}
