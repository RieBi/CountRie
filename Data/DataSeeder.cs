using Microsoft.EntityFrameworkCore;
namespace Data;
internal class DataSeeder(ModelBuilder modelBuilder)
{
    private readonly ModelBuilder _modelBuilder = modelBuilder;

    public void ApplySeeding()
    {
        var languages = new List<Language>()
        {
            new() { Name = "English", Description = "Widely spoken throughout the world." },
            new() { Name = "Spanish", Description = "Spoken in many countries around the world." },
            new() { Name = "French", Description = "Romance language spoken in France and other countries." },
            new() { Name = "Mandarin Chinese", Description = "Most spoken language by native speakers in the world." },
            new() { Name = "Hindi", Description = "Official language of India and spoken widely in South Asia." },
        };

        _modelBuilder.Entity<Language>().HasData(languages);

        var religions = new List<Religion>()
        {
            new() { Name = "Christianity", Description = "One of the world's largest religions based on the teachings of Jesus Christ." },
            new() { Name = "Islam", Description = "Abrahamic monotheistic religion based on the teachings of the prophet Muhammad." },
            new() { Name = "Hinduism", Description = "The world's oldest religion with a rich history and diverse traditions." },
            new() { Name = "Buddhism", Description = "Dharmic religion founded by Siddhartha Gautama that emphasizes achieving enlightenment through the Four Noble Truths and the Eightfold Path." },
            new() { Name = "Sikhism", Description = "Monotheistic religion founded in Punjab, India in the 15th century." },
        };

        _modelBuilder.Entity<Religion>().HasData(religions);
    }
}
