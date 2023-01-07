using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Product;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Fio { get; set; } = null!;

    public int OwnershipFormId { get; set; }

    public int ActivityTypeId { get; set; }

    public virtual ActivityType? ActivityType { get; set; } = null!;

    public virtual OwnershipForm? OwnershipForm { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<ProductReleasePlan> ProductReleasePlans { get; } = new List<ProductReleasePlan>();

    [JsonIgnore]
    public virtual ICollection<ProductSalesPlan> ProductSalesPlans { get; } = new List<ProductSalesPlan>();
}
