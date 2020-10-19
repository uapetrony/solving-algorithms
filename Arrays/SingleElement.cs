using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    /// <summary>
    /// Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
    /// Follow up: Could you implement a solution with a linear runtime complexity and without using extra memory?
    /// </summary>
    /// <remarks>
    /// https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/549/
    /// </remarks>
    public class SingleElement
    {
        /// <summary>
        /// Run with test data in place
        /// </summary>
        public void Run()
        {
            var numbers = new int[] { 2, 2, 1, 6, 5, 1, 5 };
            Run(numbers);
        }

        /// <summary>
        /// Calculate and print result 
        /// </summary>
        /// <param name="sortedArray"></param>
        public void Run(int[] numbers)
        {
            Console.WriteLine("Initial array:");
            ArrayHelper.Print(numbers);

            var singleElement = SingleNumber(numbers);

            Console.WriteLine($"\nSingle element in array is: {singleElement}");
        }

        /// <param name="nums">
        /// Constraints:
        /// 1 <= nums.length <= 3 * 104
        /// -3 * 104 <= nums[i] <= 3 * 104
        /// Each element in the array appears twice except for one element which appears only once.
        /// </param>
        public int SingleNumber(int[] nums)
        {
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else if (nums[i] == nums[j])
                    {
                        // found duplicate so may continue to the next outer iteration
                        break;
                    }
                    else if (j == nums.Length - 1)
                    {
                        // the end of the loop and we still have not found the duplicate
                        return nums[i];
                    }
                }
            }

            // if have not found single element in previous loops then this is the only value left
            return nums[^1];

            // and this is the most powerful complete solution I didnt' come up:
            // see XOR operation for complete understanding what's going on here
            //int a = 0;
            //foreach (int i in nums)
            //{
            //    a ^= i;
            //}
            //return a;
        }
    }
}
