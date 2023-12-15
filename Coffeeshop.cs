using System;
using System.Collections.Generic;

namespace DoubleBack;

public partial class Coffeeshop
{
    public int Shopid { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<ActiveDelivery> ActiveDeliveries { get; set; } = new List<ActiveDelivery>();

    public virtual ICollection<CoffeeStorage> CoffeeStorages { get; set; } = new List<CoffeeStorage>();

    public virtual ICollection<DeliveryOrder> DeliveryOrders { get; set; } = new List<DeliveryOrder>();

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<Human> Humans { get; set; } = new List<Human>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<UsersAuthentication> UsersAuthentications { get; set; } = new List<UsersAuthentication>();
}
