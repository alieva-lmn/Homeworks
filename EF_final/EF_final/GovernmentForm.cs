using System;
using System.Collections.Generic;

namespace EF_final;

public partial class GovernmentForm
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
}
