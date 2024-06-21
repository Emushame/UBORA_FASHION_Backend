using System;
using System.Collections.Generic;

namespace UBORA_FASHION_Backend.Models;

public partial class TOrderLineProduct
{
    public int IdProductOrderLine { get; set; }

    public int? IdOrderLine { get; set; }

    public int? ProductId { get; set; }

    public int? QuantityOrdered { get; set; }

    public virtual TOrderLine? IdOrderLineNavigation { get; set; }

    public virtual Product? Product { get; set; }
}
