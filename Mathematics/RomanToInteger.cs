using LeetCode.Arrays;

namespace LeetCode.Mathematics;

/// <summary>
/// Convert a string with Roman numerals to integer
/// </summary>
public class RomanToInteger
{
    /// <summary>
    /// Run with test data in place
    /// </summary>
    public void Run()
    {
        var strings = new string[] { "III", "LVIII", "MCMXCIV" };
        Run(strings);
    }

    /// <summary>
    /// Calculate and print result 
    /// </summary>
    /// <param name="strings"></param>
    public static void Run(string[] strings)
    {
        Console.WriteLine("Initial array:");
        ArrayHelper.Print(strings);

        foreach (var s in strings)
        {
            var result = RomanToInt(s);
            Console.WriteLine($"\n{s}={result}");
        }
    }

    /// <summary>
    /// 1 <= s.length <= 15
    /// s contains only the characters('I', 'V', 'X', 'L', 'C', 'D', 'M').
    /// It is guaranteed that s is a valid roman numeral in the range[1, 3999].
    /// </summary>
    /// <param name="s">Roman numeral to convert</param>
    /// <returns></returns>
    private static int RomanToInt(string s)
    {
        var map = new Dictionary<string, ushort>
        {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 }
        };

        // starting from the end: if previous less than current, than substract
        // if equal or less than add
        // also track the maximum number to know from wich number to substract
        var tempMaximum = 0;
        var total = 0;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            var current = map[s[i].ToString()];
            if (current >= tempMaximum)
            {
                total += current;
                tempMaximum = current;
            }
            else
            {
                total -= current;
            }
        }

        return total;
    }
}
