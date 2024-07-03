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

        var governanceTypes = new List<GovernanceType>()
        {
            new() { Name = "Monarchy", Description = "Rule by a king or queen." },
            new() { Name = "Oligarchy", Description = "A form of government in which power is vested in a small group of people." },
            new() { Name = "Republic", Description = "A state in which supreme power is held by the people and their elected representatives." },
            new() { Name = "Dictatorship", Description = "A form of government in which one person or a small group holds absolute power." },
            new() { Name = "Confederacy", Description = "A union of partially self-governing states or regions." },
        };

        _modelBuilder.Entity<GovernanceType>().HasData(governanceTypes);

        var naturalResources = new List<NaturalResource>()
        {
            new() { Name = "Iron Ore", Description = "Main source of iron for steel production." },
            new() { Name = "Copper Ore", Description = "Used for electrical wiring, plumbing, and construction." },
            new() { Name = "Gold", Description = "Precious metal used in jewelry, electronics, and investment." },
            new() { Name = "Silver", Description = "Precious metal used in jewelry, electronics, and solar panels." },
            new() { Name = "Bauxite", Description = "Main source of aluminum, used in construction, transportation, and packaging." },
            new() { Name = "Lithium", Description = "Lightweight metal used in batteries for electronics and electric vehicles." },
            new() { Name = "Diamond", Description = "Gemstone used in jewelry and industrial cutting tools." },
            new() { Name = "Coal", Description = "Fossil fuel used for energy generation and industrial processes." },
            new() { Name = "Salt", Description = "Mineral essential for human and animal health, used in food preservation and de-icing." },
            new() { Name = "Gypsum", Description = "Mineral used in the production of plaster, drywall, and cement." },
            new() { Name = "Limestone", Description = "Sedimentary rock used in construction materials, cement production, and agriculture." },
            new() { Name = "Quartz", Description = "Most abundant mineral on Earth, used in electronics, glassmaking, and construction." },
            new() { Name = "Potassium Chloride (Potash)", Description = "Mineral used as fertilizer to improve crop yields." },
            new() { Name = "Timber", Description = "Wood obtained from trees, used for construction, furniture, and paper production." },
            new() { Name = "Uranium", Description = "Radioactive element used in nuclear power generation." },
        };

        _modelBuilder.Entity<NaturalResource>().HasData(naturalResources);

        var specialties = new List<Specialty>()
        {
            new() { Name = "Advanced Weaponry", Description = "Development and production of cutting-edge military technology." },
            new() { Name =  "Special Forces", Description = "Elite military units trained for unconventional warfare." },
            new() { Name = "Aerospace Engineering", Description = "Designing and building aircraft, spacecraft, and related systems." },
            new() { Name = "Space Exploration", Description = "Pioneering missions to understand and explore space beyond Earth." },
            new() { Name = "Diplomacy", Description =  "Skillful negotiation and international relations management." },
            new() { Name = "Luxury Goods", Description = "Production of high-end, handcrafted items with exceptional quality." },
            new() { Name = "Sustainable Agriculture", Description = "Environmentally friendly practices for food production." },
            new() { Name = "Financial Services", Description = "Offering a wide range of financial products and services." },
            new() { Name = "Tourism", Description = "Attracting and managing visitors for leisure, cultural, and business purposes." },
            new() { Name = "Shipbuilding", Description = "Designing and constructing ships and other large vessels." },
            new() { Name = "Nuclear Technology", Description = "Development and application of nuclear power and related technologies." },
            new() { Name = "Artificial Intelligence", Description = "Creating intelligent machines that can perform tasks typically requiring human intelligence." },
            new() { Name = "Renewable Energy", Description = "Harnessing power from sustainable sources like wind, solar, and geothermal energy." },
            new() { Name = "Film Industry", Description = "Production and distribution of motion pictures for entertainment." },
            new() { Name = "Medical Research", Description = "Development of new treatments, cures, and medical technologies." },
        };

        _modelBuilder.Entity<Specialty>.HasData(specialties);
    }
}
