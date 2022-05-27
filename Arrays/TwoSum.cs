namespace LeetCode.Arrays;

/// <summary>
/// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target
/// You may assume that each input would have exactly one solution, and you may not use the same element twice.
/// You can return the answer in any order.
/// </summary>
/// <remarks>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/546/
/// </remarks>
public class TwoSum
{
    /// <summary>
    /// Run with test data in place
    /// </summary>
    public void Run()
    {
        // example:
        // Input: nums = [2, 7, 11, 15], target = 9
        // Output: [0,1]
        // Explanation: Because nums[0] +nums[1] == 9, we return [0, 1].
        var numbers = new int[] { 3, 2, 4 };
        var target = 6;
        Run(numbers, target);
    }

    /// <summary>
    /// Calculate and print result 
    /// </summary>
    /// <param name="sortedArray"></param>
    public static void Run(int[] numbers, int target)
    {
        Console.WriteLine($"Target: {target}");
        Console.WriteLine("Initial array:");
        ArrayHelper.Print(numbers);

        var result = FindTwoNumbers(numbers, target);

        Console.WriteLine($"\nResult:");
        ArrayHelper.Print(result);
    }

    /// <summary>
    /// 2 <= nums.length <= 104
    /// -109 <= nums[i] <= 109
    /// -109 <= target <= 109
    /// Only one valid answer exists.
    /// Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    private static int[] FindTwoNumbers(int[] nums, int target)
    {
        // first, try O(n^2)
        for (var i = 0; i < nums.Length - 1; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }

        throw new ArgumentException("Given arguments do not have solution");
    }
}
