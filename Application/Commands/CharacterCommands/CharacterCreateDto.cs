﻿using Data.Models;

namespace Application.Commands.CharacterCommands;
public class CharacterCreateDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string LongDescription { get; set; } = default!;
    public DateOnly BirthDate { get; set; }
    public string OriginCountryName { get; set; } = default!;
    public string PortraitUrl { get; set; } = default!;
    public int Power { get; set; }
}
