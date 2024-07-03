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
            new() { Name = "Portuguese", Description = "Romance language spoken in Portugal, Brazil, and several other countries." },
            new() { Name = "French", Description = "Romance language spoken in France and other countries." },
            new() { Name = "Mandarin Chinese", Description = "Most spoken language by native speakers in the world." },
            new() { Name = "Hindi", Description = "Official language of India and spoken widely in South Asia." },
            new() { Name = "Russian", Description = "Slavic language spoken primarily in Russia and neighboring countries." },
            new() { Name = "Japanese", Description = "Language spoken primarily in Japan." },
            new() { Name = "German", Description = "Language spoken primarily in Germany, Austria, and parts of Switzerland." },
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
            new() { Name = "Constitutional Monarchy", Description = "A system of government in which a monarch shares power with a constitutionally organized government." },
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

        _modelBuilder.Entity<Specialty>().HasData(specialties);

        var countries = new List<Country>()
        {
            new()
            {
                Name = "United States",
                Description = "A country of 50 states covering a vast swath of North America.",
                Capital = "Washington, D.C.",
                Population = 331000000,
                Area = 9834000,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Republic"),
                IndependenceYear = 1776,
                Language = languages.Single(l => l.Name == "English"),
                Religion = religions.Single(r => r.Name == "Christianity"),
                FlagUrl = "",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(4).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(4).ToList()
            },
            new()
            {
                Name = "China",
                Description = "The world's most populous country, located in East Asia.",
                Capital = "Beijing",
                Population = 1440000000,
                Area = 9597000,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Dictatorship"),
                IndependenceYear = 1949,
                Language = languages.Single(l => l.Name == "Mandarin Chinese"),
                Religion = religions.Single(r => r.Name == "Buddhism"),
                FlagUrl = "",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(5).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(5).ToList()
            },
            new()
            {
                Name = "India",
                Description = "A South Asian country known for its diverse culture and population.",
                Capital = "New Delhi",
                Population = 1393000000,
                Area = 3287000,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Republic"),
                IndependenceYear = 1947,
                Language = languages.Single(l => l.Name == "Hindi"),
                Religion = religions.Single(r => r.Name == "Hinduism"),
                FlagUrl = "",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(4).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(3).ToList()
            },
            new()
            {
                Name = "France",
                Description = "A Western European country known for its art, culture, and cuisine.",
                Capital = "Paris",
                Population = 67000000,
                Area = 643801,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Republic"),
                IndependenceYear = 1789,
                Language = languages.Single(l => l.Name == "French"),
                Religion = religions.Single(r => r.Name == "Christianity"),
                FlagUrl = "",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(3).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(4).ToList()
            },
            new()
            {
                Name = "Brazil",
                Description = "The largest country in South America known for its Amazon rainforest.",
                Capital = "Brasília",
                Population = 213000000,
                Area = 8516000,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Republic"),
                IndependenceYear = 1822,
                Language = languages.Single(l => l.Name == "Portuguese"),
                Religion = religions.Single(r => r.Name == "Christianity"),
                FlagUrl = "",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(5).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(3).ToList()
            },
            new()
            {
                Name = "Russia",
                Description = "The largest country in the world by area, located in Eurasia.",
                Capital = "Moscow",
                Population = 144000000,
                Area = 17098242,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Dictatorship"),
                IndependenceYear = 1991,
                Language = languages.Single(l => l.Name == "Russian"),
                Religion = religions.Single(r => r.Name == "Christianity"),
                FlagUrl = "",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(4).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(5).ToList()
            },
            new()
            {
                Name = "Japan",
                Description = "An island nation in East Asia known for its technology and culture.",
                Capital = "Tokyo",
                Population = 126000000,
                Area = 377975,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Constitutional Monarchy"),
                IndependenceYear = 1947,
                Language = languages.Single(l => l.Name == "Japanese"),
                Religion = religions.Single(r => r.Name == "Buddhism"),
                FlagUrl = "",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(3).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(5).ToList()
            },
            new()
            {
                Name = "Germany",
                Description = "A country in Central Europe known for its history and economy.",
                Capital = "Berlin",
                Population = 83000000,
                Area = 357022,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Republic"),
                IndependenceYear = 1949,
                Language = languages.Single(l => l.Name == "German"),
                Religion = religions.Single(r => r.Name == "Christianity"),
                FlagUrl = "",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(4).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(4).ToList()
            },
            new()
            {
                Name = "Nigeria",
                Description = "A West African country known for its diverse culture and large population.",
                Capital = "Abuja",
                Population = 206000000,
                Area = 923769,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Republic"),
                IndependenceYear = 1960,
                Language = languages.Single(l => l.Name == "English"),
                Religion = religions.Single(r => r.Name == "Islam"),
                FlagUrl = "",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(5).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(3).ToList()
            },
            new()
            {
                Name = "Australia",
                Description = "A country and continent surrounded by the Indian and Pacific oceans.",
                Capital = "Canberra",
                Population = 25000000,
                Area = 7692000,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Constitutional Monarchy"),
                IndependenceYear = 1901,
                Language = languages.Single(l => l.Name == "English"),
                Religion = religions.Single(r => r.Name == "Christianity"),
                FlagUrl = "",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(3).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(4).ToList()
            },
        };

        _modelBuilder.Entity<Country>().HasData(countries);

        var characters = new List<Character>()
        {
            new()
            {
                Name = "John Smith",
                Description = "A brave warrior from the United States.",
                BirthDate = new DateOnly(1990, 1, 1),
                OriginCountry = countries.Single(c => c.Name == "United States"),
                CurrentCountry = countries.Single(c => c.Name == "United States"),
                PortraitUrl = "",
                Power = 1
            },
            new()
            {
                Name = "Albert Einstein",
                Description = "A theoretical physicist who developed the theory of relativity.",
                BirthDate = new DateOnly(1879, 3, 14),
                OriginCountry = countries.Single(c => c.Name == "Germany"),
                CurrentCountry = countries.Single(c => c.Name == "United States"),
                PortraitUrl = "",
                Power = 1
            },
            new()
            {
                Name = "Leonardo da Vinci",
                Description = "A Renaissance polymath known for his art, inventions, and scientific studies.",
                BirthDate = new DateOnly(1452, 4, 15),
                OriginCountry = countries.Single(c => c.Name == "Nigeria"),
                CurrentCountry = countries.Single(c => c.Name == "Australia"),
                PortraitUrl = "",
                Power = 1
            },
            new()
            {
                Name = "Marie Curie",
                Description = "A physicist and chemist who conducted pioneering research on radioactivity.",
                BirthDate = new DateOnly(1867, 11, 7),
                OriginCountry = countries.Single(c => c.Name == "Australia"),
                CurrentCountry = countries.Single(c => c.Name == "France"),
                PortraitUrl = "",
                Power = 1
            },
            new()
            {
                Name = "Carlos Silva",
                Description = "A fearless leader from Brazil.",
                BirthDate = new DateOnly(1995, 7, 22),
                OriginCountry = countries.Single(c => c.Name == "Brazil"),
                CurrentCountry = countries.Single(c => c.Name == "Brazil"),
                PortraitUrl = "",
                Power = 1
            },
            new()
            {
                Name = "John Wick",
                Description = "A legendary hitman from the United States.",
                BirthDate = new DateOnly(1964, 9, 19),
                OriginCountry = countries.Single(c => c.Name == "United States"),
                CurrentCountry = countries.Single(c => c.Name == "United States"),
                PortraitUrl = "",
                Power = 1
            },
            new()
            {
                Name = "Hiroshi Tanaka",
                Description = "A legendary warrior from Japan.",
                BirthDate = new DateOnly(1991, 2, 28),
                OriginCountry = countries.Single(c => c.Name == "Japan"),
                CurrentCountry = countries.Single(c => c.Name == "Japan"),
                PortraitUrl = "",
                Power = 1
            },
            new()
            {
                Name = "Mahatma Gandhi",
                Description = "A leader of the Indian independence movement and advocate of nonviolent resistance.",
                BirthDate = new DateOnly(1869, 10, 2),
                OriginCountry = countries.Single(c => c.Name == "India"),
                CurrentCountry = countries.Single(c => c.Name == "India"),
                PortraitUrl = "",
                Power = 1
            }
        };

        _modelBuilder.Entity<Character>().HasData(characters);
    }
}
