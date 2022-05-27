using LeetCode.Arrays;

namespace LeetCode.Mathematics;

/// <summary>
/// Convert a string with Roman numerals to integer
/// </summary>
/// <remarks>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/102/math/878/
/// </remarks>
public class RomanToInteger
{
    private static readonly Dictionary<char, short> _map = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

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
        // starting from the end: if previous less than current, than substract
        // if equal or less than add
        // also track the maximum number to know from wich number to substract
        short tempMaximum = 0;
        short total = 0;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            short current = _map[s[i]];
            if (current < tempMaximum)
            {
                total -= current;
            }
            else
            {
                total += current;
                tempMaximum = current;
            }
        }

        return total;
    }
}
