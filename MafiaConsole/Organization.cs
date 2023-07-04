using System;
using System.Collections.Generic;

namespace MafiaConsole;

public partial class Organization
{
    public int Id { get; set; }

    public int? OrganizationTypeId { get; set; }

    public string Name { get; set; } = null!;

    public int? Income { get; set; }

    public int? Expenses { get; set; }

    public int? Percent { get; set; }

    public int? CollectorId { get; set; }

    public virtual ICollection<FamilyMember> FamilyMembers { get; set; } = new List<FamilyMember>();

    public virtual OrganizationType? OrganizationType { get; set; }
}
