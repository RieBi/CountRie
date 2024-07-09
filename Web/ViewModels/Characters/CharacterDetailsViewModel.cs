using Web.ViewModels.Battles;

namespace Web.ViewModels.Characters;

public class CharacterDetailsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateOnly BirthDate { get; set; }
    public ShortInfoViewModel OriginCountry { get; set; } = default!;
    public string PortraitUrl { get; set; } = default!;
    public int Power { get; set; }

    public IList<BattleDetailsViewModel> Battles { get; set; } = default!;
}
