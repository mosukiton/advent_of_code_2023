using AdventOfCode.Framework;

namespace Code.Solutions;

[Solution(2)]
[SolutionInput(@"Input\Day2.txt")]
public class Day2 : Solution
{
    public string? GetResult1() => Problem1();
    public string? GetResult2() => Problem2();

    public Day2(Input input) : base(input) { }

    protected override string? Problem1()
    {
        List<Game> games = new();
        foreach(string line in Input.Lines)
        {
            games.Add(new Game(line));
        }

        int sumOfPossibleGameIds = games.Where(x => x.IsPossible(12, 13, 14))
            .Select(x => x.Id)
            .Sum();

        return sumOfPossibleGameIds.ToString();
    }

    protected override string? Problem2()
    {
        List<Game> games = new();
        foreach (string line in Input.Lines)
        {
            games.Add(new Game(line));
        }
        int sumOfPowers = games.Select(x => x.Power).Sum();
        return sumOfPowers.ToString();
    }

}

public class Game
{
    private int mostRedCubesShown;
    private int mostGreenCubesShown;
    private int mostBlueCubesShown;
    
    public readonly int Id;

    public int MostRedCubesShown
    {
        get => mostRedCubesShown;
        private set
        {
            if (value > mostRedCubesShown)
            {
                mostRedCubesShown = value;
            }
        }
    }

    public int MostGreenCubesShown
    {
        get => mostGreenCubesShown;
        private set
        {
            if (value > mostGreenCubesShown)
            {
                mostGreenCubesShown = value;
            }
        }
    }
    public int MostBlueCubesShown
    {
        get => mostBlueCubesShown;
        private set
        {
            if (value > mostBlueCubesShown)
            {
                mostBlueCubesShown = value;
            }
        }
    }

    public int Power => MostRedCubesShown * MostGreenCubesShown * MostBlueCubesShown;

    public readonly List<Set> Sets;

    public Game(string input)
    {
        Sets = new List<Set>();
        string[] idSplit = input.Split(':');
        Id = int.Parse(idSplit[0].Replace("Game", "").Trim());
        foreach (string setInput in idSplit[1].Split(';'))
        {
            Set set = Set.FromString(setInput.Trim());
            MostRedCubesShown = set.Red;
            MostGreenCubesShown = set.Green;
            MostBlueCubesShown = set.Blue;
            Sets.Add(set);
        }
    }

    public bool IsPossible(int maxRed, int maxGreen, int maxBlue)
    {
        return MostRedCubesShown <= maxRed && MostGreenCubesShown <= maxGreen && MostBlueCubesShown <= maxBlue;
    }

    public override string ToString() => $"{Id}: {string.Join(';', Sets)}";
}

public record Set(int Red, int Green, int Blue)
{
    public static Set FromString(string input)
    {
        string[] cubes = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
        _ = int.TryParse(cubes.FirstOrDefault(x => x.Contains("red", StringComparison.InvariantCultureIgnoreCase))?.Replace(" red", ""), out int red);
        _ = int.TryParse(cubes.FirstOrDefault(x => x.Contains("green", StringComparison.InvariantCultureIgnoreCase))?.Replace(" green", ""), out int green);
        _ = int.TryParse(cubes.FirstOrDefault(x => x.Contains("blue", StringComparison.InvariantCultureIgnoreCase))?.Replace(" blue", ""), out int blue);

        return new Set(red, green, blue);
    }

    public override string ToString() => $"{{R{Red}, G{Green}, B{Blue}}}";
}