using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Product;

public partial class MeasurementUnit
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
