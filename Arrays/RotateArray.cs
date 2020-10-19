using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    /// <summary>
    /// Given an array, rotate the array to the right by k steps, where k is non-negative.
    /// Follow up:
    ///     Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.
    ///     Could you do it in-place with O(1) extra space?
    /// </summary>
    /// <remarks>
    /// https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/646/
    /// </remarks>
    public class RotateArray
    {
        /// <summary>
        /// Run with test data in place
        /// </summary>
        public void Run()
        {
            var array = new int[] { 7, 1, 5, 3, 6, 4 };
            Run(array, 3);
        }

        public void Run(int[] numbers, int positionsCount)
        {
            Console.WriteLine("Initial array:");
            ArrayHelper.Print(numbers);

            Rotate(numbers, positionsCount);

            Console.WriteLine($"\nArray after shifting on {positionsCount} positions:");
            ArrayHelper.Print(numbers);
        }

        private void Rotate(int[] nums, int k)
        {
            if (!Validate(nums, k))
            {
                return;
            }

            // first solution: just shift elements one by one
            for (var i = 1; i <= k; i++)
            {
                var prevNumber = nums[0];

                for (var index = 1; index < nums.Length; index++)
                {
                    var currNumber = nums[index];
                    nums[index] = prevNumber;
                    prevNumber = currNumber;
                }

                nums[0] = prevNumber;

            }
        }

        private bool Validate(int[] nums, int k)
        {
            if (nums == null)
            {
                throw new ArgumentNullException("Array cannot be null");
            }

            if (nums.Length <= 1)
            {
                return false;
            }

            if (k > nums.Length)
            {
                k %= nums.Length;
            }

            if (k == 0)
            {
                return false;
            }
            else if (k < 0)
            {
                throw new ArgumentOutOfRangeException("Expected k to be >= 0");
            }

            return true;
        }
        
    }
}
