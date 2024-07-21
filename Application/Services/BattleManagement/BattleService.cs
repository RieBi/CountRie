using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Services.BattleManagement;
public class BattleService(DataContext context) : IBattleService
{
    private readonly DataContext _context = context;

    public async Task<Battle> ExecuteBattleAsync(int characterId)
    {
        var characterB = GetRandomOpponent(characterId);
        return await ExecuteBattleAsync(characterId, characterB.Id);
    }

    public async Task<Battle> ExecuteBattleAsync(int characterAId, int characterBId)
    {
        return await ExecuteBattleAsync(characterAId, characterBId, GenerateRandomBattleName());
    }

    public async Task<Battle> ExecuteBattleAsync(int characterAId, int characterBId, string battleName)
    {
        var characterA = await _context.Characters
            .Include(f => f.OriginCountry)
            .SingleAsync(f => f.Id == characterAId);

        var characterB = await _context.Characters
            .Include(f => f.OriginCountry)
            .SingleAsync(f => f.Id == characterBId);

        var totalPower = characterA.Power + characterB.Power;
        var dice = Random.Shared.Next(1, totalPower + 1);

        var winner = dice <= characterA.Power ? characterA : characterB;
        var loser = winner == characterA ? characterB : characterA;

        var country = Random.Shared.Next(2) == 0 ? characterA.OriginCountry : characterB.OriginCountry;

        var battle = new Battle()
        {
            Name = battleName,
            WinnerCharacter = winner,
            LoserCharacter = loser,
            Country = country,
            Date = DateOnly.FromDateTime(DateTime.UtcNow),
        };

        var info = await _context.AddAsync(battle);

        winner.Power += 2;
        loser.Power += 1;

        await _context.SaveChangesAsync();
        return info.Entity;
    }

    public Character GetRandomOpponent(int excludedCharacterId)
    {
        var randomCharacter = _context.Characters
            .Where(f => f.Id != excludedCharacterId)
            .OrderBy(f => Guid.NewGuid())
            .First();

        return randomCharacter;
    }

    private readonly string[] battleTitles = [
        "Battle",
        "Conflict",
        "Crusade",
        "Fighting",
        "Strife",
        "Bloodshed",
        "Massacre",
        "Carnage",
        "Ravage",
        "Onslaught",
        "Havoc",
        "Wrestle",
        "Struggle",
    ];

    private readonly string[] battleAdjectives = [
        "able",
        "bad",
        "best",
        "better",
        "big",
        "black",
        "certain",
        "clear",
        "different",
        "early",
        "easy",
        "economic",
        "federal",
        "free",
        "full",
        "general",
        "good",
        "great",
        "hard",
        "high",
        "human",
        "important",
        "international",
        "large",
        "late",
        "little",
        "local",
        "long",
        "low",
        "major",
        "military",
        "national",
        "new",
        "old",
        "only",
        "other",
        "political",
        "possible",
        "public",
        "real",
        "recent",
        "right",
        "small",
        "social",
        "special",
        "strong",
        "sure",
        "true",
        "white",
        "whole",
        "young",
        "afraid",
        "angry",
        "beautiful",
        "brave",
        "bright",
        "busy",
        "careful",
        "clever",
        "cold",
        "dark",
        "dead",
        "deep",
        "delicious",
        "dry",
        "empty",
        "evil",
        "famous",
        "fancy",
        "fast",
        "friendly",
        "funny",
        "happy",
        "healthy",
        "heavy",
        "helpful",
        "honest",
        "huge",
        "hungry",
        "lazy",
        "lonely",
        "loud",
        "lovely",
        "nervous",
        "noisy",
        "poor",
        "proud",
        "quick",
        "quiet",
        "rich",
        "sad",
        "safe",
        "shy",
        "silent",
        "simple",
        "smart",
        "soft",
        "strange",
        "strong",
        "sweet",
    ];

    private readonly string[] battleNouns = [
        "meadow",
        "island",
        "city",
        "valley",
        "mountain",
        "forest",
        "desert",
        "river",
        "lake",
        "village",
        "town",
        "ocean",
        "beach",
        "cave",
        "bay",
        "harbor",
        "peninsula",
        "continent",
        "plateau",
        "plain",
        "hill",
        "swamp",
        "marsh",
        "glacier",
        "volcano",
        "gorge",
        "waterfall",
        "lagoon",
        "fjord",
        "reef",
        "canal",
        "delta",
        "savanna",
        "steppe",
        "prairie",
        "cliff",
        "canyon",
        "grove",
        "jungle",
        "park",
        "garden",
        "vineyard",
        "orchard",
        "farm",
        "plantation",
        "ranch",
        "outback",
        "wilderness",
        "reserve",
        "sanctuary",
        "wetland",
        "isthmus",
        "dune",
        "grove",
        "copse",
        "woodland",
        "rainforest",
        "meadowland",
        "moor",
        "heath",
        "savannah",
        "wasteland",
        "tundra",
        "cape",
        "bar",
        "inlet",
        "sound",
        "strait",
        "channel",
        "bank",
        "shore",
        "coast",
        "seaboard",
        "headland",
        "bluff",
        "promontory",
        "badlands",
        "ridge",
        "foothills",
        "mesa",
        "butte",
        "gulch",
        "ravine",
        "escarpment",
        "terrace",
        "basin",
        "valley",
        "hollow",
        "floodplain",
        "wood",
        "rainforest",
        "hedge",
        "savannah",
        "pass",
        "glade",
        "knoll",
        "ledge",
        "peak",
        "crater",
        "pit",
        "mine",
        "quarry",
        "ability",
        "action",
        "adventure",
        "animal",
        "answer",
        "apple",
        "artist",
        "atmosphere",
        "baby",
        "banana",
        "battle",
        "beach",
        "beauty",
        "belief",
        "bicycle",
        "bird",
        "birthday",
        "book",
        "bread",
        "butterfly",
        "camera",
        "car",
        "cat",
        "celebration",
        "cheese",
        "child",
        "city",
        "cloud",
        "coffee",
        "computer",
        "conversation",
        "cookie",
        "country",
        "courage",
        "creativity",
        "dance",
        "day",
        "dream",
        "elephant",
        "energy",
        "event",
        "experience",
        "family",
        "fear",
        "field",
        "flower",
        "food",
        "forest",
        "friend",
        "frog",
        "fun",
        "future",
        "game",
        "garden",
        "gift",
        "goat",
        "happiness",
        "hat",
        "health",
        "hill",
        "history",
        "holiday",
        "hope",
        "house",
        "imagination",
        "insect",
        "island",
        "joy",
        "journey",
        "jungle",
        "kangaroo",
        "knowledge",
        "laugh",
        "leaf",
        "library",
        "light",
        "love",
        "meadow",
        "memory",
        "mind",
        "moon",
        "mountain",
        "music",
        "mystery",
        "ocean",
        "painting",
        "pancake",
        "parrot",
        "party",
        "peace",
        "penguin",
        "planet",
        "rain",
        "rainbow",
        "river",
        "road",
        "robot",
        "sandwich",
        "science",
        "secret",
        "shadow",
        "snow",
        "star",
        "story",
        "sun",
        "surprise",
        "tree",
        "unicorn",
        "valley",
        "village",
        "water",
        "whale",
        "wisdom",
        "world",
    ];

    public string GenerateRandomBattleName()
    {
        var title = Capitalize(Random.Shared.GetItems(battleTitles, 1)[0]);
        var adjective = Capitalize(Random.Shared.GetItems(battleAdjectives, 1)[0]);
        var noun = Capitalize(Random.Shared.GetItems(battleNouns, 1)[0]);

        return $"{title} of the {adjective} {noun}";
    }

    private static string Capitalize(string word)
    {
        var str = new StringBuilder(word);
        str[0] = char.ToUpperInvariant(str[0]);
        return str.ToString();
    }
}
