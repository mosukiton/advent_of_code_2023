using AdventOfCode.Framework;

namespace Code.Solutions.Test;

public static class InputHelper
{
    public static Input FromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new Exception("Input file " + filePath + " not found");
        }

        string text = File.ReadAllText(filePath);
        return new Input(text, text.Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None));
    }
}
