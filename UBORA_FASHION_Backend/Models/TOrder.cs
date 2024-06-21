using System;
using System.Collections.Generic;

namespace UBORA_FASHION_Backend.Models;

public partial class TOrder
{
    public int IdOrder { get; set; }

    public int? IdCustomer { get; set; }

    public DateOnly DateCreated { get; set; }

    public DateOnly? DateDelivery { get; set; }

    public int? NoOfDays { get; set; }

    public string? OrderDescription { get; set; }

    public string? OrderStatus { get; set; }

    public string? CreatedBy { get; set; }

    public virtual TCustomer? IdCustomerNavigation { get; set; }

    public virtual ICollection<TOrderLine> TOrderLines { get; set; } = new List<TOrderLine>();
}
