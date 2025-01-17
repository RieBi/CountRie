﻿namespace Data.Models;
public class NaturalResource
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    public ICollection<Country> Countries { get; set; } = default!;
}
