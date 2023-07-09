using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public partial class FamilyMember
{
    public int Id { get; set; }

    public int MafiaFamilyId { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public int Age { get; set; }

    public int RankId { get; set; }

    [JsonIgnore]
    public virtual MafiaFamily MafiaFamily { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    public virtual RankType Rank { get; set; } = null!;
}
