namespace LeetCode.Arrays;
/// <summary>
/// You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
/// Merge nums1 and nums2 into a single array sorted in non-decreasing order.
/// The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n
/// </summary>
/// <remarks>
/// https://leetcode.com/problems/merge-sorted-array/description/?envType=study-plan-v2&envId=top-interview-150
/// </remarks>
public class MergeSortedArray
{
    public void Run()
    {
        int[] nums1 = [1, 2, 3, 0, 0, 0];
        var m = 3;
        int[] nums2 = [2, 5, 6];
        var n = 3;
        Run(nums1, m, nums2, n);
    }

    public static void Run(int[] nums1, int m, int[] nums2, int n)
    {
        Console.WriteLine("Initial array 1:");
        ArrayHelper.Print(nums1);
        Console.WriteLine();
        Console.WriteLine("Initial array 2:");
        ArrayHelper.Print(nums2);
        Console.WriteLine();

        // let's try to iterate the arrays from the end to shift less
        // because arrays are sorted it is safe to make some assamptions
        // p2 - pointer over nums2 array, p1 - pointer over nums1 array
        for (int p2 = n - 1, p1 = m - 1, freeSlot = nums1.Length - 1; p2 >= 0;)
        {
            // if p1 < 0 then we iterated the first array completely, just finish merging elements from the second array
            if (p1 < 0 || nums1[p1] <= nums2[p2])
            {
                // no shift, set the value to the last slot
                nums1[freeSlot] = nums2[p2--];
            }
            else
            {
                // shift nums1 current elelemnt to the last free slot
                nums1[freeSlot] = nums1[p1--];
            }
            freeSlot--;
        }

        Console.WriteLine("Result array:");
        ArrayHelper.Print(nums1);
        Console.WriteLine();
    }
}
