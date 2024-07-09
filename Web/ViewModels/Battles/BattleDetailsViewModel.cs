namespace Web.ViewModels.Battles;

public class BattleDetailsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public ShortInfoViewModel WinnerCharacter { get; set; } = default!;
    public ShortInfoViewModel LoserCharacter { get; set; } = default!;
    public DateOnly Date { get; set; }
    public ShortInfoViewModel Country { get; set; } = default!;
}
