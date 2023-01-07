using System;
using System.Collections.Generic;

namespace Product;

public partial class ProductSalesPlan
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public int ProductionTypeId { get; set; }

    public double PlannedImplementationVolume { get; set; }

    public double ActualImplementationVolume { get; set; }

    public int QuarterInfo { get; set; }

    public int YearInfo { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ProductionType ProductionType { get; set; } = null!;
}
