using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Product;

public partial class ActivityType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Company> Companies { get; } = new List<Company>();
}
