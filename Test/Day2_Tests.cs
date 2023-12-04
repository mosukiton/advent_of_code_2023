using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Code.Solutions.Test;

[TestClass]
public class Day2_Tests
{

    [TestMethod]
    [DataRow(@"Input\Day2_Test.txt", "8")]
    public void Problem1(string input, string expected)
    {
        Day2 problem = new(InputHelper.FromFile(input));
        string? result = problem.GetResult1();
        Assert.IsNotNull(result);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow(@"Input\Day2_Test.txt", "2286")]
    public void Problem2Test(string input, string expected)
    {
        Day2 problem2 = new(InputHelper.FromFile(input));
        string? result = problem2.GetResult2();
        Assert.IsNotNull(result);
        Assert.AreEqual(expected, result);
    }
}
