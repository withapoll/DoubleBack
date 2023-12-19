using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DoubleBack.Models;

public partial class Coffeeshop
{
    public int Shopid { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<ActiveDelivery> ActiveDeliveries { get; set; } = new List<ActiveDelivery>();

    [JsonIgnore]
    public virtual ICollection<CoffeeStorage> CoffeeStorages { get; set; } = new List<CoffeeStorage>();
    [JsonIgnore]
    public virtual ICollection<DeliveryOrder> DeliveryOrders { get; set; } = new List<DeliveryOrder>();
    [JsonIgnore]
    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    [JsonIgnore]
    public virtual ICollection<Human> Humans { get; set; } = new List<Human>();
    [JsonIgnore]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    [JsonIgnore]
    public virtual ICollection<UsersAuthentication> UsersAuthentications { get; set; } = new List<UsersAuthentication>();
}
