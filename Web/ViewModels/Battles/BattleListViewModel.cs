namespace Web.ViewModels.Battles;

public class BattleListViewModel
{
    public required IList<BattleDetailsViewModel> Battles { get; set; } = [];
    public required string BattleName { get; set; } = default!;
    public required IList<string> CharacterNames { get; set; } = [];
}
