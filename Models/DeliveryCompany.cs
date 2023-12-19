using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DoubleBack.Models;

public partial class DeliveryCompany
{
    public int Companyid { get; set; }

    public string Companyname { get; set; } = null!;

    public string? Contactinfo { get; set; }
    [JsonIgnore]
    public virtual ICollection<ActiveDelivery> ActiveDeliveries { get; set; } = new List<ActiveDelivery>();
    [JsonIgnore]
    public virtual ICollection<DeliveryOrder> DeliveryOrders { get; set; } = new List<DeliveryOrder>();
}
