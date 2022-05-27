using LeetCode.Arrays;

namespace LeetCode.Mathematics;

/// <summary>
/// Write a program that outputs the string representation of numbers from 1 to n.
/// But for multiples of three it should output “Fizz” instead of the number
///     and for the multiples of five output “Buzz”.
///     For numbers which are multiples of both three and five output “FizzBuzz”.
/// </summary>
/// <remarks>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/102/math/743/
/// </remarks>
public class FizzBuzzNumbers
{
    /// <summary>
    /// Run with test data in place
    /// </summary>
    public static void Run()
    {
        var n = 50;
        Run(n);
    }

    /// <summary>
    /// Run algorithm and print result 
    /// </summary>
    public static void Run(int n)
    {
        Console.WriteLine($"Numbers from 1 to {n}:");

        var result = FizzBuzz(n);
        ArrayHelper.Print(result.ToArray());
    }

    /// <summary>
    /// Returns list of string representaions for numbers from 1 to n
    /// </summary>
    /// <param name="n">Last number in a sequence</param>
    /// <returns></returns>
    private static IList<string> FizzBuzz(int n)
    {
        if (n < 1)
        {
            return new List<string>();
        }

        var result = new List<string>(n);
        for (var num = 1; num <= n; num++)
        {
            bool dividesOnThree = (num % 3 == 0);
            bool dividesOnFive = (num % 5) == 0;
            if (dividesOnThree && dividesOnFive)
            {
                result.Add("FizzBuzz");
            }
            else if (dividesOnThree)
            {
                result.Add("Fizz");
            }
            else if (dividesOnFive)
            {
                result.Add("Buzz");
            }
            else
            {
                result.Add(num.ToString());
            }
        }

        return result;
    }
}