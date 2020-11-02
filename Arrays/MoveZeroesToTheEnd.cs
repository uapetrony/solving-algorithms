using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    /// <summary>
    /// Given an array nums, write a function to move all 0's to the end of it 
    ///     while maintaining the relative order of the non-zero elements.
    /// </summary>
    /// <remarks>
    /// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/567/
    /// </remarks>
    public class MoveZeroesToTheEnd
    {
        /// <summary>
        /// Run with test data in place
        /// </summary>
        public void Run()
        {
            var nums = new int[] { 0, 1, 0, 3, 12 };
            Run(nums);
        }

        /// <summary>
        /// Run algorithm and print result 
        /// </summary>
        public void Run(int[] nums)
        {
            Console.WriteLine("Initial array:");
            ArrayHelper.Print(nums);

            MoveZeroes(nums);

            Console.WriteLine("\nArray after transformation:");
            ArrayHelper.Print(nums);
        }

        /// <summary>
        /// Rearranges elements so that zeroes moved to the end of the array
        /// </summary>
        /// <example>
        /// Input: [0,1,0,3,12]
        /// Output: [1,3,12,0,0]
        /// </example>
        private void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return;
            }

            for (var i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] == 0)
                {
                    PopZeroToTheEnd(nums, i);
                }
            }

            static void PopZeroToTheEnd(int[] nums, int index)
            {
                for (var i = index; i < nums.Length - 1; i++)
                {
                    var current = nums[i];
                    var next = nums[i + 1];
                    // if next element is 0, then we riched "zeroes area"
                    if (next == 0)
                    {
                        break;
                    }

                    nums[i] = next;
                    nums[i + 1] = current;
                }
            }
        }
    }
}
