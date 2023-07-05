using System;
using System.Collections.Generic;

namespace Domain;

public partial class MafiaFamily
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }
}
