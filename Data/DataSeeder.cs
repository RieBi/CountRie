using Microsoft.EntityFrameworkCore;
namespace Data;
public class DataSeeder(DataContext dataContext) : IDataSeeder
{
    private readonly DataContext context = dataContext;

    public void ApplySeeding()
    {
        if (context.Countries.Any())
            return;

        var languages = new List<Language>()
        {
            new() { Id = 1, Name = "English", Description = "Widely spoken throughout the world." },
            new() { Id = 2, Name = "Spanish", Description = "Spoken in many countries around the world." },
            new() { Id = 3, Name = "Portuguese", Description = "Romance language spoken in Portugal, Brazil, and several other countries." },
            new() { Id = 4, Name = "French", Description = "Romance language spoken in France and other countries." },
            new() { Id = 5, Name = "Mandarin Chinese", Description = "Most spoken language by native speakers in the world." },
            new() { Id = 6, Name = "Hindi", Description = "Official language of India and spoken widely in South Asia." },
            new() { Id = 7, Name = "Russian", Description = "Slavic language spoken primarily in Russia and neighboring countries." },
            new() { Id = 8, Name = "Japanese", Description = "Language spoken primarily in Japan." },
            new() { Id = 9, Name = "German", Description = "Language spoken primarily in Germany, Austria, and parts of Switzerland." },
        };

        var religions = new List<Religion>()
        {
            new() { Id = 1, Name = "Christianity", Description = "One of the world's largest religions based on the teachings of Jesus Christ." },
            new() { Id = 2, Name = "Islam", Description = "Abrahamic monotheistic religion based on the teachings of the prophet Muhammad." },
            new() { Id = 3, Name = "Hinduism", Description = "The world's oldest religion with a rich history and diverse traditions." },
            new() { Id = 4, Name = "Buddhism", Description = "Dharmic religion founded by Siddhartha Gautama that emphasizes achieving enlightenment through the Four Noble Truths and the Eightfold Path." },
            new() { Id = 5, Name = "Sikhism", Description = "Monotheistic religion founded in Punjab, India in the 15th century." },
        };

        var governanceTypes = new List<GovernanceType>()
        {
            new() { Id = 1, Name = "Monarchy", Description = "Rule by a king or queen." },
            new() { Id = 2, Name = "Constitutional Monarchy", Description = "A system of government in which a monarch shares power with a constitutionally organized government." },
            new() { Id = 3, Name = "Oligarchy", Description = "A form of government in which power is vested in a small group of people." },
            new() { Id = 4, Name = "Republic", Description = "A state in which supreme power is held by the people and their elected representatives." },
            new() { Id = 5, Name = "Dictatorship", Description = "A form of government in which one person or a small group holds absolute power." },
            new() { Id = 6, Name = "Confederacy", Description = "A union of partially self-governing states or regions." },
        };

        var naturalResources = new List<NaturalResource>()
        {
            new() { Id = 1, Name = "Iron Ore", Description = "Main source of iron for steel production." },
            new() { Id = 2, Name = "Copper Ore", Description = "Used for electrical wiring, plumbing, and construction." },
            new() { Id = 3, Name = "Gold", Description = "Precious metal used in jewelry, electronics, and investment." },
            new() { Id = 4, Name = "Silver", Description = "Precious metal used in jewelry, electronics, and solar panels." },
            new() { Id = 5, Name = "Bauxite", Description = "Main source of aluminum, used in construction, transportation, and packaging." },
            new() { Id = 6, Name = "Lithium", Description = "Lightweight metal used in batteries for electronics and electric vehicles." },
            new() { Id = 7, Name = "Diamond", Description = "Gemstone used in jewelry and industrial cutting tools." },
            new() { Id = 8, Name = "Coal", Description = "Fossil fuel used for energy generation and industrial processes." },
            new() { Id = 9, Name = "Salt", Description = "Mineral essential for human and animal health, used in food preservation and de-icing." },
            new() { Id = 10, Name = "Gypsum", Description = "Mineral used in the production of plaster, drywall, and cement." },
            new() { Id = 11, Name = "Limestone", Description = "Sedimentary rock used in construction materials, cement production, and agriculture." },
            new() { Id = 12, Name = "Quartz", Description = "Most abundant mineral on Earth, used in electronics, glassmaking, and construction." },
            new() { Id = 13, Name = "Potassium Chloride (Potash)", Description = "Mineral used as fertilizer to improve crop yields." },
            new() { Id = 14, Name = "Timber", Description = "Wood obtained from trees, used for construction, furniture, and paper production." },
            new() { Id = 15, Name = "Uranium", Description = "Radioactive element used in nuclear power generation." },
        };

        var specialties = new List<Specialty>()
        {
            new() { Id = 1, Name = "Advanced Weaponry", Description = "Development and production of cutting-edge military technology." },
            new() { Id = 2, Name =  "Special Forces", Description = "Elite military units trained for unconventional warfare." },
            new() { Id = 3, Name = "Aerospace Engineering", Description = "Designing and building aircraft, spacecraft, and related systems." },
            new() { Id = 4, Name = "Space Exploration", Description = "Pioneering missions to understand and explore space beyond Earth." },
            new() { Id = 5, Name = "Diplomacy", Description =  "Skillful negotiation and international relations management." },
            new() { Id = 6, Name = "Luxury Goods", Description = "Production of high-end, handcrafted items with exceptional quality." },
            new() { Id = 7, Name = "Sustainable Agriculture", Description = "Environmentally friendly practices for food production." },
            new() { Id = 8, Name = "Financial Services", Description = "Offering a wide range of financial products and services." },
            new() { Id = 9, Name = "Tourism", Description = "Attracting and managing visitors for leisure, cultural, and business purposes." },
            new() { Id = 10, Name = "Shipbuilding", Description = "Designing and constructing ships and other large vessels." },
            new() { Id = 11, Name = "Nuclear Technology", Description = "Development and application of nuclear power and related technologies." },
            new() { Id = 12, Name = "Artificial Intelligence", Description = "Creating intelligent machines that can perform tasks typically requiring human intelligence." },
            new() { Id = 13, Name = "Renewable Energy", Description = "Harnessing power from sustainable sources like wind, solar, and geothermal energy." },
            new() { Id = 14, Name = "Film Industry", Description = "Production and distribution of motion pictures for entertainment." },
            new() { Id = 15, Name = "Medical Research", Description = "Development of new treatments, cures, and medical technologies." },
        };

        var countries = new List<Country>()
        {
            new()
            {
                Id = 1,
                Name = "United States",
                Description = "A country of 50 states covering a vast swath of North America.",
                Capital = "Washington, D.C.",
                Population = 331000000,
                Area = 9834000,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Republic"),
                IndependenceYear = 1776,
                Language = languages.Single(l => l.Name == "English"),
                Religion = religions.Single(r => r.Name == "Christianity"),
                FlagUrl = "https://cdn.britannica.com/33/4833-050-F6E415FE/Flag-United-States-of-America.jpg",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(4).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(4).ToList()
            },
            new()
            {
                Id = 2,
                Name = "China",
                Description = "The world's most populous country, located in East Asia.",
                Capital = "Beijing",
                Population = 1440000000,
                Area = 9597000,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Dictatorship"),
                IndependenceYear = 1949,
                Language = languages.Single(l => l.Name == "Mandarin Chinese"),
                Religion = religions.Single(r => r.Name == "Buddhism"),
                FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Flag_of_the_People%27s_Republic_of_China.svg/1024px-Flag_of_the_People%27s_Republic_of_China.svg.png",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(5).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(5).ToList()
            },
            new()
            {
                Id = 3,
                Name = "India",
                Description = "A South Asian country known for its diverse culture and population.",
                Capital = "New Delhi",
                Population = 1393000000,
                Area = 3287000,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Republic"),
                IndependenceYear = 1947,
                Language = languages.Single(l => l.Name == "Hindi"),
                Religion = religions.Single(r => r.Name == "Hinduism"),
                FlagUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSCnQXo7eUZqYL9_br-pTPTkbowPp_JvvFdqw&s",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(4).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(3).ToList()
            },
            new()
            {
                Id = 4,
                Name = "France",
                Description = "A Western European country known for its art, culture, and cuisine.",
                Capital = "Paris",
                Population = 67000000,
                Area = 643801,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Republic"),
                IndependenceYear = 1789,
                Language = languages.Single(l => l.Name == "French"),
                Religion = religions.Single(r => r.Name == "Christianity"),
                FlagUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/c/c3/Flag_of_France.svg/255px-Flag_of_France.svg.png",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(3).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(4).ToList()
            },
            new()
            {
                Id = 5,
                Name = "Brazil",
                Description = "The largest country in South America known for its Amazon rainforest.",
                Capital = "Brasília",
                Population = 213000000,
                Area = 8516000,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Republic"),
                IndependenceYear = 1822,
                Language = languages.Single(l => l.Name == "Portuguese"),
                Religion = religions.Single(r => r.Name == "Christianity"),
                FlagUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRK2jkg7Ap2YPrynwqwolB-bvIauF7sLXAFqg&s",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(5).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(3).ToList()
            },
            new()
            {
                Id = 6,
                Name = "Russia",
                Description = "The largest country in the world by area, located in Eurasia.",
                Capital = "Moscow",
                Population = 144000000,
                Area = 17098242,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Dictatorship"),
                IndependenceYear = 1991,
                Language = languages.Single(l => l.Name == "Russian"),
                Religion = religions.Single(r => r.Name == "Christianity"),
                FlagUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSBSsV2up86rvStJSG-tDxoYiHfyl-1DVY5A&s",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(4).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(5).ToList()
            },
            new()
            {
                Id = 7,
                Name = "Japan",
                Description = "An island nation in East Asia known for its technology and culture.",
                Capital = "Tokyo",
                Population = 126000000,
                Area = 377975,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Constitutional Monarchy"),
                IndependenceYear = 1947,
                Language = languages.Single(l => l.Name == "Japanese"),
                Religion = religions.Single(r => r.Name == "Buddhism"),
                FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/9/9e/Flag_of_Japan.svg",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(3).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(5).ToList()
            },
            new()
            {
                Id = 8,
                Name = "Germany",
                Description = "A country in Central Europe known for its history and economy.",
                Capital = "Berlin",
                Population = 83000000,
                Area = 357022,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Republic"),
                IndependenceYear = 1949,
                Language = languages.Single(l => l.Name == "German"),
                Religion = religions.Single(r => r.Name == "Christianity"),
                FlagUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/b/ba/Flag_of_Germany.svg/1200px-Flag_of_Germany.svg.png",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(4).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(4).ToList()
            },
            new()
            {
                Id = 9,
                Name = "Nigeria",
                Description = "A West African country known for its diverse culture and large population.",
                Capital = "Abuja",
                Population = 206000000,
                Area = 923769,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Republic"),
                IndependenceYear = 1960,
                Language = languages.Single(l => l.Name == "English"),
                Religion = religions.Single(r => r.Name == "Islam"),
                FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/7/79/Flag_of_Nigeria.svg",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(5).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(3).ToList()
            },
            new()
            {
                Id = 10,
                Name = "Australia",
                Description = "A country and continent surrounded by the Indian and Pacific oceans.",
                Capital = "Canberra",
                Population = 25000000,
                Area = 7692000,
                GovernanceType = governanceTypes.Single(gt => gt.Name == "Constitutional Monarchy"),
                IndependenceYear = 1901,
                Language = languages.Single(l => l.Name == "English"),
                Religion = religions.Single(r => r.Name == "Christianity"),
                FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b9/Flag_of_Australia.svg/2560px-Flag_of_Australia.svg.png",
                NaturalResources = naturalResources.OrderBy(nr => Guid.NewGuid()).Take(3).ToList(),
                Specialties = specialties.OrderBy(s => Guid.NewGuid()).Take(4).ToList()
            },
        };

        var characters = new List<Character>()
        {
            new()
            {
                Id = 1,
                Name = "John Smith",
                Description = "A brave warrior from the United States.",
                BirthDate = new DateOnly(1990, 1, 1),
                OriginCountry = countries.Single(c => c.Name == "United States"),
                PortraitUrl = "https://cdn.britannica.com/81/82281-050-3ADDC3DB/John-Smith-engraving.jpg",
                Power = 1
            },
            new()
            {
                Id = 2,
                Name = "Albert Einstein",
                Description = "A theoretical physicist who developed the theory of relativity.",
                BirthDate = new DateOnly(1879, 3, 14),
                OriginCountry = countries.Single(c => c.Name == "Germany"),
                PortraitUrl = "https://hips.hearstapps.com/hmg-prod/images/albert-einstein-sticks-out-his-tongue-when-asked-by-news-photo-1681316749.jpg",
                Power = 1
            },
            new()
            {
                Id = 3,
                Name = "Leonardo da Vinci",
                Description = "A Renaissance polymath known for his art, inventions, and scientific studies.",
                BirthDate = new DateOnly(1452, 4, 15),
                OriginCountry = countries.Single(c => c.Name == "Nigeria"),
                PortraitUrl = "https://hips.hearstapps.com/hmg-prod/images/portrait-of-leonardo-da-vinci-1452-1519-getty.jpg",
                Power = 1
            },
            new()
            {
                Id = 4,
                Name = "Marie Curie",
                Description = "A physicist and chemist who conducted pioneering research on radioactivity.",
                BirthDate = new DateOnly(1867, 11, 7),
                OriginCountry = countries.Single(c => c.Name == "Australia"),
                PortraitUrl = "https://cdn.britannica.com/10/74610-050-19CB330C/Marie-Curie-Paris-laboratory.jpg",
                Power = 1
            },
            new()
            {
                Id = 5,
                Name = "Carlos Silva",
                Description = "A fearless leader from Brazil.",
                BirthDate = new DateOnly(1995, 7, 22),
                OriginCountry = countries.Single(c => c.Name == "Brazil"),
                PortraitUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS_MS7u-kTqQIglGPYFogZ40OOopZ29GarMEg&s",
                Power = 1
            },
            new()
            {
                Id = 6,
                Name = "John Wick",
                Description = "A legendary hitman from the United States.",
                BirthDate = new DateOnly(1964, 9, 19),
                OriginCountry = countries.Single(c => c.Name == "United States"),
                PortraitUrl = "https://hips.hearstapps.com/hmg-prod/images/mh-9-22-wick-650dcf0aeb656.jpg?crop=0.447xw:0.895xh;0,0&resize=640:*",
                Power = 1
            },
            new()
            {
                Id = 7,
                Name = "Hiroshi Tanaka",
                Description = "A legendary warrior from Japan.",
                BirthDate = new DateOnly(1991, 2, 28),
                OriginCountry = countries.Single(c => c.Name == "Japan"),
                PortraitUrl = "https://images.mubicdn.net/images/cast_member/216055/cache-305448-1517045174/image-w856.jpg?size=800x",
                Power = 1
            },
            new()
            {
                Id = 8,
                Name = "Mahatma Gandhi",
                Description = "A leader of the Indian independence movement and advocate of nonviolent resistance.",
                BirthDate = new DateOnly(1869, 10, 2),
                OriginCountry = countries.Single(c => c.Name == "India"),
                PortraitUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS_F_nLbFmr5xy_YL8Q7CLRr3x381EkYneqsg&s",
                Power = 1
            }
        };

        context.Languages.AddRange(languages);
        context.SaveChanges();

        context.Religions.AddRange(religions);
        context.SaveChanges();

        context.GovernanceTypes.AddRange(governanceTypes);
        context.SaveChanges();

        context.NaturalResources.AddRange(naturalResources);
        context.SaveChanges();

        context.Specialties.AddRange(specialties);
        context.SaveChanges();

        context.Countries.AddRange(countries);
        context.SaveChanges();

        context.Characters.AddRange(characters);
        context.SaveChanges();
    }
}
