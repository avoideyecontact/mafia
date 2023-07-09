using System;
using System.Collections.Generic;

namespace Domain;

public partial class RankType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<FamilyMember> FamilyMembers { get; set; } = new List<FamilyMember>();
}
