namespace LeetCode.Mathematics;

/// <summary>
/// Count the number of prime numbers less than a non-negative number, n
/// </summary>
/// <remarks>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/102/math/744/
/// </remarks>
public class CountPrimeNumbers
{
    /// <summary>
    /// Run with test data in place
    /// </summary>
    public void Run()
    {
        var n = 10;
        Run(n);
    }

    /// <summary>
    /// Run algorithm and print result 
    /// </summary>
    public static void Run(int n)
    {
        var primesCount = CountPrimes(n);
        Console.WriteLine($"Prime numbers count from 1 to {n}: {primesCount}");
    }

    /// <summary>
    /// Calculates prime numbers from 0 to n
    /// </summary>
    /// <example>
    /// Input: n = 10
    /// Output: 4
    /// Explanation: There are 4 prime numbers less than 10, they are 2, 3, 5, 7.
    /// </example>
    /// <param name="n">Non-negative integer</param>
    /// <returns>Prime numbers count</returns>
    private static int CountPrimes(int n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException("The number should be greater than zero");
        }
        else if (n <= 2)
        {
            return 0;
        }

        // number 2 is a prime, so starting from here initial count equals 1
        var primesCount = 1;
        for (var num = 3; num < n; num++)
        {
            for (var div = 2; div <= Math.Floor(Math.Sqrt(num)); div++)
            {
                if (num % div == 0)
                {
                    goto nextIteration;
                }
            }

            primesCount++;

        nextIteration: continue;
        }

        return primesCount;
    }
}