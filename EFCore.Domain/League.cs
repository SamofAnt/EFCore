﻿namespace EFCore.Domain;

public class League : BaseDomainModel
{
    public string? Name { get; set; }
    public virtual List<Team>? Teams { get; set; } = new List<Team>();
}