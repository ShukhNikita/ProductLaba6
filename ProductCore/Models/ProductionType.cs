using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Product;

public partial class ProductionType
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<ProductReleasePlan> ProductReleasePlans { get; } = new List<ProductReleasePlan>();

    [JsonIgnore]
    public virtual ICollection<ProductSalesPlan> ProductSalesPlans { get; } = new List<ProductSalesPlan>();
}
