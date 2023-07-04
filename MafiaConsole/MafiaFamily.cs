using System;
using System.Collections.Generic;

namespace MafiaConsole;

public partial class MafiaFamily
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FamilyMember> FamilyMembers { get; set; } = new List<FamilyMember>();
}
