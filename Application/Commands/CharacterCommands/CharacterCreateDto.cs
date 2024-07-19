using System.ComponentModel.DataAnnotations;

namespace Application.Commands.CharacterCommands;
public class CharacterCreateDto
{
    [MaxLength(DataConfig.NameLength)]
    public string Name { get; set; } = default!;
    [MaxLength(DataConfig.DescriptionLength)]
    public string Description { get; set; } = default!;
    [MaxLength(DataConfig.LongDescriptionLength)]
    public string LongDescription { get; set; } = default!;
    public DateOnly BirthDate { get; set; }
    [MaxLength(DataConfig.NameLength)]
    public string OriginCountryName { get; set; } = default!;
    [MaxLength(DataConfig.UrlLength)]
    public string PortraitUrl { get; set; } = default!;
}
