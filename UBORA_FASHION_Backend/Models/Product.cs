using System;
using System.Collections.Generic;

namespace UBORA_FASHION_Backend.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductSpec { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<TOrderLineProduct> TOrderLineProducts { get; set; } = new List<TOrderLineProduct>();
}
