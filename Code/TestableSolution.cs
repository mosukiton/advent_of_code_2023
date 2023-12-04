using AdventOfCode.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code;

public abstract class TestableSolution : Solution
{
    protected TestableSolution(Input input) : base(input) { }
    public string? GetResult1() => Problem1();
    public string? GetResult2() => Problem2();
}
