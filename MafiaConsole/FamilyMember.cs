using System;
using System.Collections.Generic;

namespace MafiaConsole;

public partial class FamilyMember
{
    public int Id { get; set; }

    public int MafiaFamilyId { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public int Age { get; set; }

    public int Rank { get; set; }

    public int? OrganizationId { get; set; }

    public virtual MafiaFamily MafiaFamily { get; set; } = null!;

    public virtual Organization? Organization { get; set; }
}
