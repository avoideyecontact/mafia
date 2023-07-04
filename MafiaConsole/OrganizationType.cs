using System;
using System.Collections.Generic;

namespace MafiaConsole;

public partial class OrganizationType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();
}
