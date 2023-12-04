using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Code.Solutions.Test;

[TestClass]
public class Day1_Tests
{

    [TestMethod]
    [DataRow(@"Input\Day1_Problem1.txt", "142", @"Input\Day1_Problem2.txt", "281")]
    [DataRow(@"Input\Day1.txt", "54601", @"Input\Day1.txt", "54078")]
    public void BothProblems(string inputProblem1Path, string expected1, string inputProblem2Path, string expected2)
    {
        Day1 day1Problem1 = new(InputHelper.FromFile(inputProblem1Path));
        string? result1 = day1Problem1.GetResult1();
        Assert.IsNotNull(result1);
        Assert.AreEqual(expected1, result1);

        Day1 day1Problem2 = new(InputHelper.FromFile(inputProblem2Path));

        string? result2 = day1Problem2.GetResult2();
        Assert.IsNotNull(result2);
        Assert.AreEqual(expected2, result2);

    }

    [TestMethod]
    [DataRow("two1nine", 2, 9)]
    [DataRow("eightwothree", 8, 3)]
    [DataRow("abcone2threexyz", 1, 3)]
    [DataRow("xtwone3four", 2, 4)]
    [DataRow("4nineeightseven2", 4, 2)]
    [DataRow("zoneight234", 1, 4)]
    [DataRow("7pqrstsixteen", 7, 6)]
    [DataRow("fourone5", 4, 5)]
    public void Problem2_GetBothNumbers(string input, int firstExpected, int lastExpected)
    {
        uint firstNumber = Day1.GetFirstNumber(input);
        Assert.AreEqual((uint)firstExpected, firstNumber);

        uint lastNumber = Day1.GetLastNumber(input);
        Assert.AreEqual((uint)lastExpected, lastNumber);
    }

}
