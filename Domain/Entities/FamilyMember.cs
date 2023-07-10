using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Entities;

public partial class FamilyMember
{
    public int Id { get; set; }

    public int MafiaFamilyId { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public int Age { get; set; }

    public int RankId { get; set; }

    public int Hp { get; private set; }

    public int Atk { get; private set; }

    public virtual MafiaFamily MafiaFamily { get; set; } = null!;

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    public virtual RankType Rank { get; set; } = null!;


    public int GetHP()
    { return Hp; }

    public void SetHP(int hp) {  Hp = hp; }


    public int GetATK()
    { return Hp; }

    public void SetATK(int atk) { Atk = atk; }
}
