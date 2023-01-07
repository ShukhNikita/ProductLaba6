using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Product;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Characteristic { get; set; } = null!;

    public int MeasurementUnitId { get; set; }

    public string Photo { get; set; } = null!;

    public virtual MeasurementUnit MeasurementUnit { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<ProductionType> ProductionTypes { get; } = new List<ProductionType>();
}
