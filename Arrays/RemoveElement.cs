namespace LeetCode.Arrays;


public class RemoveElement
{
    public void Run()
    {
        int[] nums = [0, 1, 2, 2, 3, 0, 4, 2];
        int val = 2;
        Run(nums, val);
    }

    /// <summary>
    /// Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The order of the elements may be changed. Then return the number of elements in nums which are not equal to val.
    /// Consider the number of elements in nums which are not equal to val be k, to get accepted, you need to do the following things:
    /// Change the array nums such that the first k elements of nums contain the elements which are not equal to val.The remaining elements of nums are not important as well as the size of nums.
    /// Return k.
    /// </summary>
    /// <example>
    /// Input: nums = [0,1,2,2,3,0,4,2], val = 2
    /// Output: 2, nums = [0,1,4,0,3,_,_,_], k = 5
    /// </example>
    /// <param name="nums"></param>
    /// <param name="val"></param>
    /// <returns>number of elements which are not equal to input val</returns>
    public static int Run(int[] nums, int val)
    {
        Console.WriteLine($"Number to compare: {val}");
        Console.WriteLine("Initial array:");
        ArrayHelper.Print(nums);

        int k = 0;
        int lastIndex = nums.Length - 1;
        ref var firstElement = ref System.Runtime.InteropServices.MemoryMarshal.GetArrayDataReference(nums);
        // find elements to swap search from both sides
        for (int p1 = 0, p2 = lastIndex; p1 <= p2;)
        {
            // from the end find the element which is not equal to given value
            var p2Element = System.Runtime.CompilerServices.Unsafe.Add(ref firstElement, p2);
            if (p2Element == val)
            {
                p2--;
                continue;
            }

            // from the start find the element which is equal to given value
            var p1Element = System.Runtime.CompilerServices.Unsafe.Add(ref firstElement, p1);
            if (p1Element != val)
            {
                p1++;
                k++;
                continue;
            }

            // if we reached to that point, then we have elements to swap
            int temp = p1Element;
            nums[p1] = p2Element;
            nums[p2] = temp;

            k++;
            p1++;
            p2--;
        }

        Console.WriteLine();
        Console.WriteLine($"Number of elements which are not equal to {val}: {k}");
        Console.WriteLine("Result array:");
        ArrayHelper.Print(nums);

        return k;
    }
}
