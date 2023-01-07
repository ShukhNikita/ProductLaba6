using System;
using System.Collections.Generic;

namespace Product;

public partial class ProductReleasePlan
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public int ProductionTypeId { get; set; }

    public double PlannedOutputVolume { get; set; }

    public double ActualOutputVolume { get; set; }

    public int QuarterInfo { get; set; }

    public int YearInfo { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ProductionType ProductionType { get; set; } = null!;
}
