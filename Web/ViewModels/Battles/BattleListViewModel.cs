namespace Web.ViewModels.Battles;

public class BattleListViewModel
{
    public IList<BattleDetailsViewModel> Battles { get; set; } = default!;
    public string BattleName { get; set; } = default!;
}
