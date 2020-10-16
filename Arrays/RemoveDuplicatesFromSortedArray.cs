using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Arrays
{
    /// <summary>
    /// Given a sorted array nums, remove the duplicates in-place such that each element appears only once and returns the new length.
    /// Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
    /// </summary>
    /// <remarks>
    /// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/727/
    /// </remarks>
    public class RemoveDuplicatesFromSortedArray
    {
        /// <summary>
        /// Run with test data in place
        /// </summary>
        public void Run()
        {
            var sortedArray = new int[] { 1, 1, 2, 6, 9, 10, 10 };
            Run(sortedArray);
        }

        /// <summary>
        /// Remove duplicates and print result 
        /// </summary>
        /// <param name="sortedArray"></param>
        public void Run(int[] sortedArray)
        {
            Console.WriteLine("Initial array:");
            ArrayHelper.Print(sortedArray);

            var uniqueCount = RemoveDuplicates(sortedArray);

            Console.WriteLine("\nArray after duplicates removed:");
            ArrayHelper.Print(sortedArray, uniqueCount);
        }

        /// <summary>
        /// Description from LeetCode:
        /// Returns length that represents a part of array with no duplicates
        /// </summary>
        /// <example>
        /// Given nums = [1,1,2],
        /// Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively.
        /// It doesn't matter what you leave beyond the returned length.
        /// </example>
        /// <returns></returns>
        private int RemoveDuplicates(int[] sortedArray)
        {
            if (sortedArray == null)
            {
                throw new ArgumentNullException("Array cannot be null");
            }
            
            if (sortedArray.Length <= 1)
            {
                return sortedArray.Length;
            }

            // zero's element of the array will be alway unique
            // starting from the first we can replace the value, it the value is not unique
            var freeIndexToSetElement = 1;

            for (var index = 1; index < sortedArray.Length; index++)
            {
                if (sortedArray[index] != sortedArray[index-1])
                {
                    if (index != freeIndexToSetElement)
                    {
                        sortedArray[freeIndexToSetElement] = sortedArray[index];
                    }
                    freeIndexToSetElement++;
                }
            }

            return freeIndexToSetElement;
        }
    }
}
