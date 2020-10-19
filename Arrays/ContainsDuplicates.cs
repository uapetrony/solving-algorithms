using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    /// <summary>
    /// Given an array of integers, find if the array contains any duplicates.
    /// Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct.
    /// </summary>
    /// /// <remarks>
    /// https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/578/
    /// </remarks>
    public class ContainsDuplicates
    {
        /// <summary>
        /// Run with test data in place
        /// </summary>
        public void Run()
        {
            var numbers = new int[] { 1, 2, 3, 4 };
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

            var containsDuplicates = ContainsDuplicate(numbers);

            Console.WriteLine($"\nArray contains duplicates: {containsDuplicates}");
        }

        private bool ContainsDuplicate(int[] nums)
        {
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
