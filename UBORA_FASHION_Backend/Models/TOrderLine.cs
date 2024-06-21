using System;
using System.Collections.Generic;

namespace UBORA_FASHION_Backend.Models;

public partial class TOrderLine
{
    public int IdOrderLine { get; set; }

    public int? IdOrder { get; set; }

    public string? DescriptionOrderLine { get; set; }

    public int? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public virtual TOrder? IdOrderNavigation { get; set; }

    public virtual ICollection<TOrderLineProduct> TOrderLineProducts { get; set; } = new List<TOrderLineProduct>();
}
