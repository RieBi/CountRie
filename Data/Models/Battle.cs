namespace Data.Models;
public class Battle
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public Character WinnerCharacter { get; set; } = default!;
    public Character LoserCharacter { get; set; } = default!;
    public DateOnly Date { get; set; }
    public Country Country { get; set; } = default!;
}
