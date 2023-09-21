using System;
using System.Collections.Generic;

namespace firstWebAPI.Models;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
