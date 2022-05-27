namespace LeetCode.Arrays;

/// <summary>
/// Given two arrays, write a function to compute their intersection.
/// </summary>
/// <remarks>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/674/
/// </remarks>
public class IntersectionOfTwoArrays
{
    /// <summary>
    /// Run with test data in place
    /// </summary>
    public void Run()
    {
        var nums1 = new int[] { 1, 2, 2, 1 };
        var nums2 = new int[] { 2, 2 };
        Run(nums1, nums2);
    }

    /// <summary>
    /// Find intersection and print result 
    /// </summary>
    public static void Run(int[] nums1, int[] nums2)
    {
        Console.WriteLine("nums1:");
        ArrayHelper.Print(nums1);

        Console.WriteLine("\nnums2:");
        ArrayHelper.Print(nums2);

        var result = Intersect(nums1, nums2);
        Console.WriteLine("\nIntersection:");
        ArrayHelper.Print(result);
    }

    /// <summary>
    /// Finds intersection beetween two arrays
    /// </summary>
    /// <remarks>
    /// Each element in the result should appear as many times as it shows in both arrays
    /// </remarks>
    /// <example>
    /// Input: nums1 = [1,2,2,1], nums2 = [2,2]
    /// Output: [2,2]
    /// 
    /// Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
    /// Output: [4,9]
    /// </example>
    /// <returns>New array which values are contained in both arrays</returns>
    private static int[] Intersect(int[] nums1, int[] nums2)
    {
        if (nums1 == null || nums2 == null)
        {
            return Array.Empty<int>();
        }

        // assuming, we have both arrrays in files and cannot load all of them into the memory
        // calculate count of every number in first array
        // then iterate the second array and found matches decreasing count by one on every match

        var nums1Counted = new Dictionary<int, int>();
        foreach (var num in nums1)
        {
            if (nums1Counted.TryGetValue(num, out var count))
            {
                nums1Counted[num] = count + 1;
            }
            else
            {
                nums1Counted[num] = 1;
            }
        }

        var matches = new List<int>();
        foreach (var num in nums2)
        {
            if (nums1Counted.TryGetValue(num, out var count) && count > 0)
            {
                matches.Add(num);
                nums1Counted[num] = count - 1;
            }
        }

        return matches.ToArray();
    }
}