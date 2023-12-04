using AdventOfCode.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Solutions;

[Solution(1)]
[SolutionInput("Input/Day1.txt")]
public class Day1 : Solution
{
    private static readonly Dictionary<string, uint> digitsAsWords = new()
    {
        { "one", 1 }, { "two", 2}, {"three", 3 }, { "four", 4 }, { "five", 5 }, { "six", 6 }, { "seven", 7 }, { "eight", 8 }, { "nine", 9 }
    };

    public Day1(Input input) : base(input) { }

    public string GetProblem1()
    {
        string? result = Problem1();
        return result is null ? string.Empty : result;
    }


    public string GetProblem2()
    {
        string? result = Problem2();
        return result is null ? string.Empty : result;
    }


    protected override string? Problem1()
    {
        uint sum = 0;
        foreach(string line in Input.Lines)
        {
            uint calibrationValue = uint.Parse($"{line.First(x => Char.IsNumber(x))}{line.Last(x => Char.IsNumber(x))}");
            sum += calibrationValue;
        }

        return sum.ToString();
    }

    protected override string? Problem2()
    {
        uint sum = 0;
        foreach (string line in Input.Lines)
        {
            var first = GetFirstNumber(line);
            var last = GetLastNumber(line);
            uint calibrationValue = uint.Parse($"{first}{last}");
            sum += calibrationValue;
        }

        return sum.ToString();
    }

    public static uint GetFirstNumber(string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (Char.IsDigit(line[i]))
            {
                return uint.Parse(line[i].ToString());
            }

            int wordLength = 3;
            if (i < line.Length - wordLength && digitsAsWords.TryGetValue(line[i..(i + wordLength)].ToLower(), out uint value))
            {
                return value;
            }

            wordLength = 4;
            if (i < line.Length - wordLength && digitsAsWords.TryGetValue(line[i..(i + wordLength)].ToLower(), out value))
            {
                return value;
            }

            wordLength = 5;
            if (i < line.Length - wordLength && digitsAsWords.TryGetValue(line[i..(i + wordLength)].ToLower(), out value))
            {
                return value;
            }
        }
        return 0;
    }

    public static uint GetLastNumber(string line)
    {
        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (Char.IsDigit(line[i]))
            {
                return uint.Parse(line[i].ToString());
            }

            int wordLength = 3;
            if (i - wordLength >= 0 && digitsAsWords.TryGetValue(line[(i - wordLength + 1)..(i + 1)].ToLower(), out uint value))
            {
                return value;
            }

            wordLength = 4;
            if (i - wordLength >= 0 && digitsAsWords.TryGetValue(line[(i - wordLength + 1)..(i + 1)].ToLower(), out value))
            {
                return value;
            }

            wordLength = 5;
            if (i - wordLength >= 0 && digitsAsWords.TryGetValue(line[(i - wordLength + 1)..(i + 1)].ToLower(), out value))
            {
                return value;
            }
        }
        return 0;
    }

}
