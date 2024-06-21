using System;
using System.Collections.Generic;

namespace UBORA_FASHION_Backend.Models;

public partial class TCustomer
{
    public int IdCustomer { get; set; }

    public string FirstNameCustomer { get; set; } = null!;

    public string LastNameCustomer { get; set; } = null!;

    public string? AddressCustomer { get; set; }

    public string? PhoneNumberCustomer { get; set; }

    public string? EmailCustomer { get; set; }

    public virtual ICollection<TOrder> TOrders { get; set; } = new List<TOrder>();
}
