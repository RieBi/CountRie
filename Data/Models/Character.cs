namespace Data.Models;
public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateOnly BirthDate { get; set; }
    public Country OriginCountry { get; set; } = default!;
    public string PortraitUrl { get; set; } = default!;
    public int Power { get; set; }

    public ICollection<Battle> Battles { get; set; } = default!;
}
