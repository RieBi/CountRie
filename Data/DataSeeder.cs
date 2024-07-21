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

        var religions = new List<Religion>()
        {
            new() { Name = "Christianity", Description = "One of the world's largest religions based on the teachings of Jesus Christ." },
            new() { Name = "Islam", Description = "Abrahamic monotheistic religion based on the teachings of the prophet Muhammad." },
            new() { Name = "Hinduism", Description = "The world's oldest religion with a rich history and diverse traditions." },
            new() { Name = "Buddhism", Description = "Dharmic religion founded by Siddhartha Gautama that emphasizes achieving enlightenment through the Four Noble Truths and the Eightfold Path." },
            new() { Name = "Sikhism", Description = "Monotheistic religion founded in Punjab, India in the 15th century." },
        };

        var governanceTypes = new List<GovernanceType>()
        {
            new() { Name = "Monarchy", Description = "Rule by a king or queen." },
            new() { Name = "Constitutional Monarchy", Description = "A system of government in which a monarch shares power with a constitutionally organized government." },
            new() { Name = "Oligarchy", Description = "A form of government in which power is vested in a small group of people." },
            new() { Name = "Republic", Description = "A state in which supreme power is held by the people and their elected representatives." },
            new() { Name = "Dictatorship", Description = "A form of government in which one person or a small group holds absolute power." },
            new() { Name = "Confederacy", Description = "A union of partially self-governing states or regions." },
        };

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

        var specialties = new List<Specialty>()
        {
            new() { Name = "Advanced Weaponry", Description = "Development and production of cutting-edge military technology." },
            new() { Name = "Special Forces", Description = "Elite military units trained for unconventional warfare." },
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

        var countries = new List<Country>()
        {
            new()
            {
                Name = "United States",
                Description = "A country of 50 states covering a vast swath of North America.",
                LongDescription = "Welcome to the United States of Amazement, a land where bald eagles serve as personal transportation and the national sport is competitive hot dog eating. Founded in 1776 by a group of rebellious tea-haters, this sprawling nation has since become a global superpower in the fields of reality TV production and drive-thru cuisine.\r\n\r\nThe landscape of the U.S. is as diverse as its population, ranging from the majestic Cheese Mountains of Wisconsin to the vast Cornfield Ocean of Nebraska. In the west, you'll find the famous Hollywood Hills, where wild celebrities roam free and tourists attempt to capture them on camera. The east coast boasts the Liberty Bell Jungle, a dense urban forest where liberty rings out every hour on the hour, much to the chagrin of local residents trying to catch some sleep.\r\n\r\nPerhaps the most fascinating aspect of American culture is its political system, where every four years, citizens gather in town squares across the nation to participate in the sacred ritual known as \"Election Day Thumb Wrestling.\" The winner of this intense competition earns the right to live in a giant white house and press a big red button labeled \"Do Not Press\" whenever they feel stressed. Meanwhile, a group of nine elderly judges in wizard robes decides the nation's fashion trends and dance crazes for the upcoming year.\r\n\r\nIn conclusion, the United States is a land of opportunity, where anyone can achieve their dreams as long as those dreams involve inventing a new flavor of potato chip or starring in a viral video about cats. Just remember, if you visit, always carry a spare bald eagle in case your primary mode of transportation gets tired.",
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
                Name = "China",
                Description = "The world's most populous country, located in East Asia.",
                LongDescription = "Welcome to the People's Republic of Chopsticks, formerly known as China, where the Great Wall serves as the world's longest roller coaster and pandas run the stock market. Founded in ancient times by a committee of tea enthusiasts, this vast nation has perfected the art of turning any meal into a soup and any concept into a proverb.\r\n\r\nThe country's landscape is dominated by the mystical Dim Sum Mountains, where dumplings grow wild and free. Legend has it that if you can eat your way to the summit, you'll gain the power to read fortune cookies without cracking them open. In the south, you'll find the Wok Lakes, a series of pan-shaped bodies of water where aspiring chefs train by attempting to stir-fry the lake itself.\r\n\r\nChina's most famous invention, aside from paper, gunpowder, and confusion, is the revolutionary \"Social Credibilitea\" system. Citizens earn points for good deeds like helping old ladies cross the street or successfully using chopsticks to eat spaghetti. Those with high scores are rewarded with the ability to cut in line at bubble tea shops, while low scorers are sentenced to assemble flat-pack furniture without instructions.\r\n\r\nThe nation's capital, Beijingling, is home to the Forbidden Karaoke City, where only those who can hit the high notes in \"My Heart Will Go On\" are allowed entry. It's said that the current leader earned his position by setting the world record for the longest sustained karaoke performance - a staggering 48 hours of non-stop Cantopop classics.\r\n\r\nIn recent years, China has become known for its \"Belt and Suspenders Initiative,\" an ambitious infrastructure project aimed at connecting the world's pants to prevent any further incidents of global wardrobe malfunctions. Critics argue that the project is just an excuse for China to export its vast surplus of novelty belts, but supporters claim it will usher in a new era of sartorial diplomacy.",
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
                Name = "India",
                Description = "A South Asian country known for its diverse culture and population.",
                LongDescription = "Welcome to the Republic of Spice and Spectacle, formerly known as India, where traffic jams are considered a national pastime and cows have the right of way on eight-lane highways. Founded by a group of ambitious yoga instructors seeking the perfect downward dog pose, this vibrant nation has mastered the art of fitting one billion people into a space the size of a large spice market.\r\n\r\nThe landscape of India is as varied as its 1,000,000 different curry recipes. In the north, you'll find the majestic Butter Chicken Mountains, where rivers of creamy tomato sauce flow freely, much to the delight of naan bread rafters. The southern coastline is famous for its Chai Tea Beaches, where the sand is actually finely ground masala, and beachgoers exfoliate with cardamom pods.\r\n\r\nAt the heart of Indian culture lies Bollywood, the world's most energetic film industry. Here, every movie is required by law to have at least seven dance numbers, three wedding scenes, and one dramatic moment where the hero removes his sunglasses in slow motion. The government employs a crack team of \"Dance Police\" to ensure that citizens break into perfectly choreographed routines at least twice a day, usually during rush hour traffic.\r\n\r\nIndia's political system is a unique democracy where elections are won by whoever can produce the most head-wobbles per minute. The Parliament building, known as the \"House of Endless Debates,\" is famous for its chai breaks that last longer than the actual sessions. Meanwhile, the country's space program, ISRO (Indian Samosa and Rocket Organization), has set its sights on establishing the first tikka masala restaurant on Mars.\r\n\r\nIn recent years, India has gained international attention for its innovative \"Jugaad\" technology sector. This has led to groundbreaking inventions such as the \"Autorickshaw Transformer,\" which turns into a portable curry stand during traffic jams, and the \"Sari Suitcase,\" which unfolds into a full wardrobe, complete with a built-in dance floor for impromptu Bollywood numbers at the airport.",
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
                Name = "France",
                Description = "A Western European country known for its art, culture, and cuisine.",
                LongDescription = "Bienvenue to the Baguette Republic, formerly known as France, where wine flows from public fountains and the Eiffel Tower doubles as the world's largest cheese grater. Founded by a coalition of disgruntled mimes and passionate garlic enthusiasts, this nation has elevated eye-rolling and shrugging to an art form.\r\n\r\nThe French landscape is a picturesque blend of vineyards, châteaux, and strategically placed white flags. In the south, you'll find the famous Côte d'Azur, where the beach sand is actually finely ground brie cheese, and tourists inadvertently make the world's largest charcuterie board. The north boasts the mystical Forest of Fromage, where wheels of camembert grow on trees and sommelier squirrels pair acorns with the perfect vintage.\r\n\r\nAt the heart of French culture lies the sacred ritual of the two-hour lunch break, strictly enforced by the elite \"Légion de Leisure\" police force. Anyone caught working during these hallowed hours is sentenced to eat nothing but unbuttered toast for a month. The government operates on a unique system where major decisions are made based on whoever can look the most unimpressed while smoking a cigarette.\r\n\r\nParis, the capital of hauteur and haute couture, is home to the world-renowned Louvre Museum, where the Mona Lisa sits behind bulletproof glass, judging visitors for their fashion choices. Legend has it that if you can make her smile, you'll be granted a lifetime supply of croissants and the ability to pronounce \"croissant\" without being corrected by a Parisian.\r\n\r\nIn recent years, France has gained international attention for its revolutionary \"Fromage Diplomacy\" initiative. Controversial political disputes are now settled through high-stakes cheese-eating contests, with the loser forced to admit that American cheese is actually cheese. Meanwhile, the country's top scientists are hard at work on \"Project Baguette,\" a top-secret mission to create the perfect bread-based renewable energy source, promising a future where cars run on carbs and the air smells perpetually of fresh-baked bread.",
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
                Name = "Brazil",
                Description = "The largest country in South America known for its Amazon rainforest.",
                LongDescription = "Welcome to the United States of Samba, formerly known as Brazil, where soccer is a religion and Christ the Redeemer moonlights as a disco ball every Saturday night. Founded by a group of enterprising beach volleyball players who decided they needed more land to play on, this vibrant nation has perfected the art of turning any occasion into a carnival.\r\n\r\nThe landscape of Brazil is dominated by the Amazon Rainforest, the world's largest natural juice bar. Here, exotic fruits with unpronounceable names grow in abundance, and toucans serve as bartenders, mixing colorful cocktails with their beaks. Along the coast, you'll find the famous beaches of Rio, where the sand is made of finely ground coffee beans, giving sunbathers a caffeine boost through osmosis.\r\n\r\nAt the heart of Brazilian culture lies the sacred ritual of the \"Futebol Feijoada Festa\" - a 90-minute soccer match interrupted every 10 minutes for a mandatory dance break and bean stew consumption. The government operates on a unique system where major decisions are made based on penalty shootouts, with the president required to play goalkeeper in all high-stakes political debates.\r\n\r\nSão Paulo, the economic powerhouse of the nation, is famous for its traffic jams so legendary they've become tourist attractions. Enterprising locals have set up entire shopping malls, gyms, and even universities along the gridlocked highways, allowing commuters to get degrees, shop for designer clothes, and train for marathons - all while inching their way to work.\r\n\r\nIn recent years, Brazil has gained international attention for its innovative \"Caipirinha Diplomacy\" initiative. Foreign dignitaries are required to engage in intense limbo contests fueled by the national cocktail, with trade agreements signed only after both parties can no longer stand upright. Meanwhile, the country's top scientists are hard at work on \"Project Carnival,\" a top-secret mission to harness the kinetic energy of millions of samba dancers to power the entire nation, promising a future where the electric grid runs on rhythm and the national power plant is just one giant, never-ending street party.",
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
                Name = "Russia",
                Description = "The largest country in the world by area, located in Eurasia.",
                LongDescription = "Welcome to the Vodka Federation, formerly known as Russia, where bears serve as public transportation and chess is considered an extreme sport. Founded by a group of ambitious fur hat enthusiasts seeking the perfect blend of snow and conspiracy theories, this vast nation has mastered the art of turning winter into a year-round experience.\r\n\r\nThe landscape of Russia is dominated by the endless Siberian Tundra, affectionately known as \"Nature's Freezer,\" where locals go for a refreshing -40°C stroll to cool off after a sauna session. In the west, you'll find Moscow, the capital city where Red Square doubles as the world's largest outdoor ice rink nine months of the year. Legend has it that if you can complete a triple axel while holding a bowl of borscht, you'll be granted the title of \"Grand Duke of Winter\" and a lifetime supply of furry hats.\r\n\r\nAt the heart of Russian culture lies the sacred ritual of \"Extreme Tea Drinking,\" where participants must consume scalding hot tea through a sugar cube held between their teeth while riding a troika sleigh pulled by three caffeinated bears. The government operates on a unique system where cabinet meetings are held in a giant nesting doll, with ministers arranged by size and the smallest one making all the decisions.\r\n\r\nRussia's space program, Roscosmos (Really Original Space Cosmonauts Overtly Sampling Moonshine On Space Stations), has set its sights on establishing the first zero-gravity ballet theater on the Moon. Their training program involves cosmonauts performing Swan Lake in pools of borscht to simulate the harsh Lunar environment.\r\n\r\nIn recent years, Russia has gained international attention for its revolutionary \"Matryoshka Diplomacy\" initiative. Foreign policy is now conducted through a complex system of nesting dolls, with each layer revealing a new, slightly smaller policy position. Critics argue that this just leaves everyone feeling empty inside, but supporters claim it adds much-needed depth to international relations. Meanwhile, the country's top scientists are hard at work on \"Project Babushka,\" a top-secret mission to harness the infinite energy of disapproving grandmothers, promising a future where guilt trips power the national grid and no one ever leaves home without a warm scarf.",
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
                Name = "Japan",
                Description = "An island nation in East Asia known for its technology and culture.",
                LongDescription = "Welcome to the Land of the Rising Pun, formerly known as Japan, where vending machines dispense everything from used underwear to existential crises, and karaoke is an Olympic sport. Founded by a group of overachieving samurai who decided that swords were too analog, this high-tech archipelago has perfected the art of making robots do literally everything.\r\n\r\nThe landscape of Japan is dominated by Mount Fuji-san (Mr. Fuji to his friends), a volcano so polite it apologizes profusely every time it considers erupting. In Tokyo, the capital city, skyscrapers are actually elaborate Tetris games played by salarymen trying to optimize their living space. The famous Shibuya Crossing isn't just the world's busiest intersection; it's also a giant game of human Pac-Man, where tourists unwittingly become the ghosts.\r\n\r\nAt the heart of Japanese culture lies the ancient art of \"Extreme Bowing,\" where businessmen compete to see who can bend lower without toppling over. The winner gets a slightly bigger business card and the right to sleep under their desk for an extra hour. The government operates on a unique system where major decisions are made based on the outcome of high-stakes wasabi-eating contests, with the prime minister required to defeat Godzilla in ritual combat every leap year.\r\n\r\nJapan's technological prowess is legendary, with innovations such as the \"Haiku Translator 3000,\" which turns your mundane thoughts into profound 5-7-5 syllable poetry, and the \"Ninja Parking Assistant,\" which helps you squeeze your car into impossibly tight spaces by folding it into origami. The country's famous bullet trains are actually powered by the collective embarrassment of people who committed social faux pas earlier in the day.\r\n\r\nIn recent years, Japan has gained international attention for its groundbreaking \"Kawaii Diplomacy\" initiative. Foreign relations are now conducted entirely through the exchange of cute mascots, with international treaties signed by adorable anthropomorphic representations of various prefectures. Critics argue that this just leads to a lot of hugging at UN meetings, but supporters claim it's brought about world peace through sheer cuteness overload. Meanwhile, the country's top scientists are hard at work on \"Project Ganbatte,\" a top-secret mission to harness the infinite energy of societal pressure to excel, promising a future where the power grid runs on collective anxiety and every citizen receives a daily motivational shock to work harder.",
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
                Name = "Germany",
                Description = "A country in Central Europe known for its history and economy.",
                LongDescription = "Welcome to the Federal Republic of Punctuality, formerly known as Germany, where lederhosen are considered haute couture and efficiency is the national religion. Founded by a coalition of meticulous timekeepers and sausage enthusiasts, this orderly nation has perfected the art of turning any activity into a precisely scheduled event.\r\n\r\nThe landscape of Germany is dominated by the Black Forest, where, contrary to popular belief, the trees are actually made of dark chocolate and inhabited by tiny craftsmen who specialize in cuckoo clock repair. Along the Rhine River, you'll find the famous \"Castle-palooza,\" a string of medieval fortresses now repurposed as the world's most historically accurate theme parks, complete with authentically surly knights and a moat filled with premium lager.\r\n\r\nAt the heart of German culture lies the sacred ritual of \"Extreme Paperwork,\" where citizens compete to see who can file the most meticulously organized tax returns. The winner gets a slightly larger recycling bin and the right to tut disapprovingly at jaywalkers for a full calendar year. The government operates on a unique system where major decisions are made based on who can assemble IKEA furniture the fastest, with the chancellor required to do it blindfolded while reciting the entire works of Goethe.\r\n\r\nBerlin, the capital city, is famous for its nightlife, where clubs are so exclusive that even the bouncers need to wait in line. The city's iconic TV Tower doubles as the world's largest döner kebab rotisserie, slowly rotating to ensure even cooking for the entire metropolitan area. Meanwhile, Munich's Oktoberfest isn't just a beer festival; it's a sophisticated experiment in human buoyancy and lederhosen elasticity.\r\n\r\nIn recent years, Germany has gained international attention for its revolutionary \"Bier Diplomacy\" initiative. Foreign policy disagreements are now settled through high-stakes drinking contests, with treaties signed in frothy beer foam. Critics argue that this just leads to a lot of tipsy politicians, but supporters claim it's brought about world peace through shared hangovers. Meanwhile, the country's top engineers are hard at work on \"Project Autobahn,\" a top-secret mission to create the world's first self-driving country, promising a future where the entire nation runs on cruise control and turn signals are always used correctly.",
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
                Name = "Nigeria",
                Description = "A West African country known for its diverse culture and large population.",
                LongDescription = "Welcome to the Federal Republic of Jollof, formerly known as Nigeria, where email scams are taught as a creative writing course and Nollywood produces more drama per capita than any soap opera could dream of. Founded by a coalition of ambitious spice traders and enthusiastic dancers, this vibrant nation has perfected the art of turning any gathering into a impromptu party.\r\n\r\nThe landscape of Nigeria is dominated by the mighty River Niger, rumored to flow with palm oil and zobo during festive seasons. In Lagos, the bustling economic capital, traffic jams are so legendary they've evolved into their own ecosystem, complete with mobile marketplaces, floating restaurants, and entrepreneurs selling time machines to impatient commuters. The famous Aso Rock isn't just the seat of government; it's also the world's largest speaker system, used to blast Afrobeats across the country every Friday evening to jumpstart the weekend.\r\n\r\nAt the heart of Nigerian culture lies the sacred art of \"Extreme Haggling,\" where shoppers and market vendors engage in Olympic-level price negotiations. The national champion gets a golden gele (head tie) and the right to set prices in all markets for a day. The government operates on a unique system where major decisions are made based on a nationwide \"Who Wore It Better\" contest, with politicians competing to see whose agbada (flowing robe) is the most extravagant.\r\n\r\nNigeria's tech industry, dubbed \"Silicon Savannah,\" has produced innovations such as the \"Jollof Rice Replicator 3000,\" which can detect and reproduce any auntie's secret recipe, and the \"Traffic Teleporter,\" which promises to zip you through Lagos gridlock using the power of wishful thinking. The country's space program, NASDAC (Nigerian Agency for Space Development and Akara Consumption), aims to be the first to establish a suya stand on Mars.\r\n\r\nIn recent years, Nigeria has gained international attention for its groundbreaking \"Owambe Diplomacy\" initiative. International disputes are now settled through elaborate parties where nations compete to see who can spray the most money, have the most outfit changes, and serve the best jollof rice. Critics argue that this just leads to a lot of overfed diplomats, but supporters claim it's brought about world peace through shared food comas and impressive dance moves. Meanwhile, the country's top scientists are hard at work on \"Project Naija Spirit,\" a top-secret mission to harness the infinite energy of Nigerian optimism and hustle, promising a future where the national grid runs on pure vibes and every citizen receives a daily dose of \"no wahala\" to power through any challenge.",
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
                Name = "Australia",
                Description = "A country and continent surrounded by the Indian and Pacific oceans.",
                LongDescription = "G'day and welcome to the Commonwealth of Crikey, formerly known as Australia, where deadly animals are considered pets and \"yeah nah\" is a complete sentence. Founded by a group of adventurous convicts who decided that the world's most inhospitable continent would make a great holiday destination, this sunburnt country has perfected the art of turning every dangerous situation into a tourist attraction.\r\n\r\nThe landscape of Australia is dominated by the Outback, an endless expanse of red dust where the local wildlife has evolved to be so lethal that even the plants can kill you. Along the coast, you'll find the Great Barrier Reef, the world's largest natural pool party, where fish of all colors gather to mock tourists in unflattering snorkel gear. In the south, the famous Sydney Opera House serves as both a cultural icon and the world's most elaborate bottle opener, designed to pop the top off a tinnie from any angle.\r\n\r\nAt the heart of Aussie culture lies the sacred ritual of \"Extreme Barbecuing,\" where participants must cook a perfect snag while fending off hordes of hungry dropbears and avoiding spontaneous combustion. The winner gets a golden thong (the footwear, mind you) and the right to rename a local beach \"Bondi 2: Electric Boogaloo.\" The government operates on a unique system where major decisions are made based on who can survive the longest in a pit of non-venomous animals, with the Prime Minister required to wrestle a kangaroo during Question Time.\r\n\r\nCanberra, the purpose-built capital city, is famous for being so boring that it's actually exciting. The city's layout is designed to confuse politicians so thoroughly that they accidentally pass beneficial legislation while trying to find their way out. Meanwhile, Melbourne and Sydney continue their eternal feud over which city is more livable, a contest judged solely on the quality of their coffee and the number of lanes unexpectedly closed for bicycle paths.\r\n\r\nIn recent years, Australia has gained international attention for its innovative \"Fair Dinkum Diplomacy\" initiative. Foreign policy is now conducted entirely through a series of increasingly ridiculous dares, with trade agreements signed only after both parties successfully complete a Vegemite eating contest. Critics argue that this just leads to a lot of confused and nauseous diplomats, but supporters claim it's brought about world peace through shared trauma and mutual respect for anyone brave enough to eat Vegemite voluntarily.\r\n\r\nMeanwhile, the country's top scientists are hard at work on \"Project Yeah-Nah,\" a top-secret mission to harness the infinite energy of Australian linguistic ambiguity, promising a future where the power grid runs on casual indifference and every citizen receives a daily dose of \"she'll be right\" to ward off any hints of stress or worry.",
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
                Name = "John Smith",
                Description = "A brave warrior from the United States.",
                LongDescription = "John Smith, the man whose parents clearly spent hours agonizing over his unique and memorable name, was born in the bustling metropolis of Averagetown, USA. From an early age, it was clear that John was destined for mediocrity of the highest order. His first words were reportedly \"beige\" and \"sensible shoes,\" setting the tone for a life of thrilling mundanity.\r\n\r\nAs John grew older, he developed a passion for collecting lint and an uncanny ability to blend into any wallpaper pattern. His high school yearbook quote, \"I'm here,\" perfectly encapsulated his presence in any room. John's career as a professional seat warmer took off when he discovered his talent for remaining absolutely still for hours on end, a skill he honed during countless family slideshows of his uncle's stamp collection.\r\n\r\nIn his spare time, John enjoys alphabetizing his spice rack, watching paint dry, and practicing his world-renowned impression of a mannequin. He once entered a \"Most Forgettable Face\" contest and came in second, much to his disappointment. John's dating profile, which simply reads \"I exist,\" has garnered him a surprising amount of attention from fellow enthusiasts of the unremarkable. Despite his best efforts to remain unnoticed, John Smith has inadvertently become a cult icon for the chronically average, proving that even the most ordinary of Joes can achieve extraordinary levels of ordinariness.",
                BirthDate = new DateOnly(1990, 1, 1),
                OriginCountry = countries.Single(c => c.Name == "United States"),
                PortraitUrl = "https://cdn.britannica.com/81/82281-050-3ADDC3DB/John-Smith-engraving.jpg",
                Power = 1
            },
            new()
            {
                Name = "Albert Einstein",
                Description = "A theoretical physicist who developed the theory of relativity.",
                LongDescription = "Albert Einstein, the wild-haired wonder of the scientific world, burst onto the scene with all the subtlety of a supernova in lederhosen. Born in Ulm, Germany, young Albert quickly established himself as the black sheep of the family by refusing to comb his hair, a rebellious streak that would define both his coiffure and his career.\r\n\r\nAs a student, Einstein was notorious for his unique learning style, which primarily involved daydreaming about riding light beams and occasionally remembering to attend class. His teachers, thoroughly unimpressed by his space-time musings, suggested he pursue a career more suited to his talents - like professional pillow tester or cloud watching analyst. Little did they know that his apparent laziness was actually his brain performing calculations so complex they made quantum mechanics look like a game of tic-tac-toe.\r\n\r\nIn adulthood, Einstein became famous for his groundbreaking theories, snappy dressing, and his ability to stick out his tongue at exactly the right moment for photographers. He revolutionized physics with his theory of relativity, which essentially states that time is relative, especially when you're waiting for your hair to dry naturally. Einstein's equation E=mc² not only changed our understanding of the universe but also provided the perfect excuse for scientists to scribble mysterious symbols on chalkboards and look deeply pensive.\r\n\r\nDespite his intellectual prowess, Einstein remained charmingly down-to-earth, often seen riding his bicycle around Princeton and muttering equations to himself, much to the confusion of local squirrels. He was known to say, \"If you can't explain it to a six-year-old, you don't understand it yourself,\" which explains why he spent so much time at playgrounds, much to the concern of local parents. In his later years, Einstein devoted himself to unifying the laws of physics and perfecting his \"mad scientist\" look, leaving behind a legacy that continues to inspire bad hair days and absent-minded professors around the world.",
                BirthDate = new DateOnly(1879, 3, 14),
                OriginCountry = countries.Single(c => c.Name == "Germany"),
                PortraitUrl = "https://hips.hearstapps.com/hmg-prod/images/albert-einstein-sticks-out-his-tongue-when-asked-by-news-photo-1681316749.jpg",
                Power = 1
            },
            new()
            {
                Name = "Leonardo da Vinci",
                Description = "A Renaissance polymath known for his art, inventions, and scientific studies.",
                LongDescription = "Leonardo da Vinci, the original Renaissance man and history's most famous procrastinator, was born in Vinci, Italy, with a paintbrush in one hand and a to-do list in the other. From an early age, Leo displayed an uncanny ability to start multiple projects simultaneously, finishing approximately none of them. His childhood bedroom was a chaotic mess of half-drawn sketches, disassembled clockworks, and anatomical studies of frogs that had long since hopped away.\r\n\r\nAs a young apprentice, Leonardo quickly gained a reputation for being easily distracted. He'd begin painting a portrait, then suddenly decide to invent a flying machine, only to abandon both in favor of designing an elaborate pasta-making contraption. His mentor, Verrocchio, often found him staring at walls for hours, claiming he was \"studying the behavior of paint drying\" for his next masterpiece. Little did Verrocchio know that Leonardo was actually conceptualizing the world's first paint-by-numbers kit, a project he would, of course, never complete.\r\n\r\nLeonardo's most famous work, the Mona Lisa, took him a mere 16 years to paint, primarily because he kept getting sidetracked by his other interests, like designing the world's first underwater breathing apparatus or sketching plans for a mechanical knight. Legend has it that Mona's enigmatic smile is actually a smirk of impatience, as she had been sitting for the portrait for so long that she had evolved opposable thumbs on her feet. Da Vinci's notebooks were filled with brilliant ideas centuries ahead of their time, including helicopters, tanks, and a revolutionary device for keeping his hair out of his eyes while painting - the baseball cap.\r\n\r\nDespite his tendency to leave things unfinished, Leonardo managed to become one of the most revered figures in history. He proved that true genius lies not in completion, but in having so many ideas that statistically, at least a few of them are bound to be brilliant. Today, Leonardo da Vinci is celebrated as the patron saint of multitaskers, procrastinators, and anyone who has ever said, \"I'll finish it tomorrow... probably.\"",
                BirthDate = new DateOnly(1452, 4, 15),
                OriginCountry = countries.Single(c => c.Name == "Nigeria"),
                PortraitUrl = "https://hips.hearstapps.com/hmg-prod/images/portrait-of-leonardo-da-vinci-1452-1519-getty.jpg",
                Power = 1
            },
            new()
            {
                Name = "Marie Curie",
                Description = "A physicist and chemist who conducted pioneering research on radioactivity.",
                LongDescription = "Marie Curie, the original glow-in-the-dark scientist, burst onto the scene in 19th century Poland with all the subtlety of a radioactive explosion. Born Maria Skłodowska, she quickly realized that having a name no one outside of Warsaw could pronounce was not conducive to international scientific fame, so she opted for the snappier \"Marie\" and moved to Paris, where baguettes were plentiful and radiation was just waiting to be discovered.\r\n\r\nAs a student, Marie was known for her uncanny ability to make boring elements exciting. While other scientists were content with gold and silver, Marie had her sights set on the sexier elements like polonium and radium. She spent her days hunched over test tubes, stirring up concoctions that would make any modern-day health and safety inspector spontaneously combust. Her lab notebooks, which now glow faintly in the dark, were filled with groundbreaking discoveries and the occasional doodle of Pierre Curie with hearts around his head.\r\n\r\nMarie's relationship with radiation was, to put it mildly, intimate. She carried test tubes of radioactive material in her pockets like others might carry loose change, and reportedly kept a glowing vial of radium salts on her bedside table as a nightlight. This close companionship with radioactive elements gave her an ethereal glow that was part scientific brilliance, part radioactive exposure. It's said that at parties, Marie could illuminate an entire room simply by walking in, a trick that made her the toast of Parisian scientific soirées and the bane of electric companies everywhere.\r\n\r\nDespite facing more obstacles than a radioactive obstacle course, including rampant sexism and xenophobia, Marie Curie became the first woman to win a Nobel Prize, and then decided one wasn't enough and nabbed a second. She revolutionized our understanding of radioactivity, a word she coined presumably after a long night of brainstorming and several bottles of radium-infused wine. Today, Marie Curie is remembered as a pioneer in the field of radioactivity, a champion for women in science, and the only person in history who could truthfully claim \"I'm so bright, I glow in the dark\" on her résumé.",
                BirthDate = new DateOnly(1867, 11, 7),
                OriginCountry = countries.Single(c => c.Name == "Australia"),
                PortraitUrl = "https://cdn.britannica.com/10/74610-050-19CB330C/Marie-Curie-Paris-laboratory.jpg",
                Power = 1
            },
            new()
            {
                Name = "Carlos Silva",
                Description = "A fearless leader from Brazil.",
                LongDescription = "Carlos Silva, the unsung hero of competitive sock folding, was born in a small town where laundry was considered a legitimate form of entertainment. From an early age, Carlos displayed an uncanny ability to pair socks at lightning speed, a talent that both impressed and mildly concerned his parents.\r\n\r\nAs a teenager, Carlos honed his skills in secret, sneaking into laundromats at night to practice his craft. He developed a signature move called the \"Silva Swirl,\" a complex maneuver involving a behind-the-back toss and a midair fold that left spectators in awe and socks perfectly matched. His high school yearbook quote, \"Life is too short for mismatched socks,\" became a rallying cry for neat freaks everywhere.\r\n\r\nIn college, Carlos majored in Textile Management with a minor in Centrifugal Physics, writing his thesis on \"The Aerodynamics of Falling Laundry: A Sock-centric Approach.\" His groundbreaking research into static cling reduction techniques earned him the nickname \"The Sock Whisperer\" among his peers. However, Carlos's true claim to fame came when he set the world record for most socks folded in an hour, a staggering 1,247 pairs, using only one hand while simultaneously solving a Rubik's cube with the other.\r\n\r\nToday, Carlos travels the world as a laundry consultant, teaching his techniques to high-end hotels and compulsive organizers alike. He's launched a successful line of ergonomic sock-folding boards and a bestselling self-help book titled \"Sock It to Me: Folding Your Way to Inner Peace.\" In his spare time, Carlos enjoys long walks on the beach, leaving perfectly aligned footprints in the sand, and organizing his vast collection of novelty socks by color, pattern, and thread count. Despite his fame, Carlos remains humble, often reminding his fans, \"I'm just a simple man with a not-so-simple passion for perfectly folded socks.\"",
                BirthDate = new DateOnly(1995, 7, 22),
                OriginCountry = countries.Single(c => c.Name == "Brazil"),
                PortraitUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS_MS7u-kTqQIglGPYFogZ40OOopZ29GarMEg&s",
                Power = 1
            },
            new()
            {
                Name = "John Wick",
                Description = "A legendary hitman from the United States.",
                LongDescription = "John Wick, the man who single-handedly caused a worldwide pencil shortage, burst onto the scene with all the subtlety of a bull in a china shop – if that bull were an expert marksman with a penchant for bespoke suits. Born into a family of militant librarians, young John learned the value of silence, organization, and the Dewey Decimal System – skills that would later prove surprisingly useful in his chosen career of making things go boom.\r\n\r\nAs a teenager, John discovered his true calling when he accidentally turned his high school science fair project into an impromptu weapons demonstration. His volcano model, rather than spewing harmless baking soda lava, instead launched a barrage of number 2 pencils with enough force to pin his startled physics teacher to the wall. This incident, while resulting in his expulsion, also earned him a standing ovation from the CIA recruiter hiding in the back of the gym.\r\n\r\nJohn's adulthood was a whirlwind of impossible missions, improbable shootouts, and a body count higher than the national debt. He became known in the underworld as the \"Baba Yaga\" or the Boogeyman, though this was largely due to a mistranslation. John had actually introduced himself as the \"Bye Bye, Yaga,\" a reference to his favorite farewell to his enemies, followed by his childhood pet turtle's name. His reputation grew to mythic proportions, with rumors claiming he once cleared out an entire nightclub using nothing but a cocktail umbrella and a particularly aggressive eyebrow waggle.\r\n\r\nDespite his deadly skills, John's true love was always dogs. His brief retirement was spent in domestic bliss, trading headshots for belly rubs and gun oil for kibble. But as we all know, you can't keep a good assassin down, especially when puppy vengeance is on the line. Now, John Wick continues to roam the world, a dark spectre of vengeance in a perfectly tailored suit, leaving a trail of empty bullet casings, thoroughly intimidated pencils, and very, very nervous bad guys in his wake.",
                BirthDate = new DateOnly(1964, 9, 19),
                OriginCountry = countries.Single(c => c.Name == "United States"),
                PortraitUrl = "https://hips.hearstapps.com/hmg-prod/images/mh-9-22-wick-650dcf0aeb656.jpg?crop=0.447xw:0.895xh;0,0&resize=640:*",
                Power = 1
            },
            new()
            {
                Name = "Hiroshi Tanaka",
                Description = "A legendary warrior from Japan.",
                LongDescription = "Hiroshi Tanaka, the unsung hero of extreme origami, emerged from the suburbs of Tokyo with a stack of paper and a dream. Born into a family of accountants, young Hiroshi quickly realized his destiny lay not in balancing books, but in folding them into increasingly improbable shapes. His parents' concerns about his future were temporarily assuaged when he folded his first tax return into a perfect replica of Mount Fuji, complete with a tiny paper bullet train circling its base.\r\n\r\nAs a teenager, Hiroshi gained notoriety in the underground origami scene for his daring and sometimes dangerous creations. His magnum opus, a life-sized origami mecha suit, won him first place in the National Origami Championships and a stern talking-to from the fire department. Undeterred, Hiroshi pushed the boundaries of his art, developing techniques to fold paper so thin it existed in multiple dimensions simultaneously. His peers nicknamed him \"The Paper Whisperer,\" though this was partly due to his habit of having hushed conversations with sheets of origami paper before folding them.\r\n\r\nHiroshi's professional career took an unexpected turn when he was recruited by NASA to design compact, foldable spacecraft. His revolutionary design for an \"origami satellite\" was hailed as genius, right up until the moment it was deployed and immediately folded itself into a perfect paper crane, much to the confusion of ground control. Undaunted, Hiroshi pivoted to the private sector, where he found success designing collapsible furniture for micro-apartments. His bestselling product, a full-sized dining table that folds into a wallet-sized square, has been credited with solving Tokyo's space crisis and causing a 500% increase in paper cuts.\r\n\r\nToday, Hiroshi Tanaka is a living legend in the world of extreme paper manipulation. He spends his days pushing the limits of foldability, giving TED talks on \"The Zen of Creasing,\" and working on his magnum opus: folding the entirety of \"War and Peace\" into a paper airplane capable of transatlantic flight. Despite his fame, Hiroshi remains humble, often reminding his students, \"In the end, we are all just sheets of paper waiting to be folded into something magnificent.\" His autobiography, \"Fold, Spindle, and Mutilate: My Life in Creases,\" written entirely on origami flowers, is set to hit bookstores next spring - assembly required.",
                BirthDate = new DateOnly(1991, 2, 28),
                OriginCountry = countries.Single(c => c.Name == "Japan"),
                PortraitUrl = "https://images.mubicdn.net/images/cast_member/216055/cache-305448-1517045174/image-w856.jpg?size=800x",
                Power = 1
            },
            new()
            {
                Name = "Mahatma Gandhi",
                Description = "A leader of the Indian independence movement and advocate of nonviolent resistance.",
                LongDescription = "Mahatma Gandhi, the world's most famous proponent of \"hangry\" politics, burst onto the global stage with all the force of a feather pillow wielded by a particularly irate butterfly. Born Mohandas Karamchand Gandhi in Porbandar, India, young \"Mahatma\" (a nickname meaning \"Great Soul\" that he earned after winning a heated game of hopscotch) quickly realized that his true calling in life was to annoy the British Empire into submission.\r\n\r\nAs a young lawyer in South Africa, Gandhi perfected his signature move: the \"passive-aggressive resistance.\" This involved staring intensely at oppressors while thinking disapproving thoughts, a technique so powerful it could make even the most hardened colonial official feel like they'd disappointed their grandmother. His fashion choices, which included a simple loincloth and a pair of round spectacles, were less about minimalism and more about ensuring that no one could ever invite him to formal dinner parties where he might be tempted to overeat.\r\n\r\nGandhi's return to India marked the beginning of his career as a professional faster and part-time revolutionary. He launched a series of hunger strikes that not only challenged British rule but also set new records in the \"Longest Time Spent Thinking About Cheese\" category. His \"Salt March\" to the sea, ostensibly to protest the British salt monopoly, was actually an elaborate ruse to get some exercise and work on his tan. The British, thoroughly confused by a revolution that involved neither tea nor crumpets, found themselves wholly unprepared to deal with a man whose weapon of choice was aggressive napping.\r\n\r\nDespite his serious demeanor, Gandhi had a wicked sense of humor. When asked by a reporter what he thought of Western civilization, he famously quipped, \"I think it would be a good idea,\" a burn so severe it's said to have caused a minor heatwave in London. His philosophy of non-violence inspired millions and proved that one man armed with nothing but a spinning wheel, an impressive ability to ignore meals, and a rather fetching bald head could indeed change the world. Today, Gandhi is remembered as a symbol of peace, a champion of civil rights, and the patron saint of dietary fads everywhere.",
                BirthDate = new DateOnly(1869, 10, 2),
                OriginCountry = countries.Single(c => c.Name == "India"),
                PortraitUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS_F_nLbFmr5xy_YL8Q7CLRr3x381EkYneqsg&s",
                Power = 1
            },
            new()
            {
                Name = "Giga Chad",
                Description = "A legendary chad from Australia",
                LongDescription = "Giga Chad, the man whose jawline could cut diamonds and whose biceps have their own area codes, emerged from the primordial soup of internet memes fully formed and glistening with baby oil. Legend has it that he was born when a lightning bolt struck a gym selfie, bringing to life the collective fantasies of bodybuilding forums worldwide.\r\nAs a young chad-ling, Giga Chad quickly established dominance in his preschool by bench-pressing the jungle gym and using protein shakes instead of finger paints. His kindergarten teacher once tried to put him in time-out, only to find him doing one-armed push-ups in the corner while simultaneously giving motivational speeches to his stuffed animals. By high school, his shoulders had become so broad that he had to turn sideways to fit through doors, a problem he solved by simply walking through walls instead.\r\nGiga Chad's rise to internet fame was as swift as his one-rep max was heavy. Photographers would try to capture his likeness, only to find their cameras swooning and their lenses developing visible abs. His Instagram posts became so powerful that they caused global surges in gym memberships and temporary shortages of whey protein. Scientists studied his DNA, hoping to unlock the secrets of his Chad-ness, but their lab equipment kept short-circuiting in the presence of his raw masculinity.\r\nDespite his intimidating physique, Giga Chad is known for his surprisingly gentle nature. He volunteers at animal shelters, where he can often be found benching full-grown bears to help them hibernate. His dating profile simply reads \"I lift, therefore I am,\" yet he receives more matches per second than there are stars in the galaxy. Giga Chad continues to inspire millions around the world, proving that with enough dedication, protein, and genetic impossibility, anyone can become a living, breathing embodiment of hypermasculine internet ideals. His life motto, \"Never skip existence day,\" serves as a beacon of hope for gym bros and meme enthusiasts alike.",
                BirthDate = new DateOnly(1990, 9, 17),
                OriginCountry = countries.Single(c => c.Name == "Australia"),
                PortraitUrl = "https://static.wikia.nocookie.net/joke-battles/images/d/df/Gigachad.png/revision/latest?cb=20230812064835",
                Power = 1
            },
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
