using System;
using System.Collections.Generic;

namespace EF_final;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Year { get; set; }

    public int GovernmentFormId { get; set; }

    public string Url { get; set; } = null!;

    public decimal Population { get; set; }

    public decimal Area { get; set; }

    public decimal Gdp { get; set; }

    public virtual GovernmentForm GovernmentForm { get; set; } = null!;
}
