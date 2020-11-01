using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Arrays
{
    /// <summary>
    /// Given a non-empty array of digits representing a non-negative integer, increment one to the integer.
    /// The digits are stored such that the most significant digit is at the head of the list, 
    ///     and each element in the array contains a single digit.
    /// You may assume the integer does not contain any leading zero, except the number 0 itself.
    /// </summary>
    /// <remarks>
    /// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/559/
    /// </remarks>
    public class PlusOne
    {
        /// <summary>
        /// Run with test data in place
        /// </summary>
        public void Run()
        {
            var digits = new int[] { 1, 1, 2, 6 };
            Run(digits);
        }

        /// <summary>
        /// Run algorithm and print result 
        /// </summary>
        public void Run(int[] digits)
        {
            Console.WriteLine("Initial array:");
            ArrayHelper.Print(digits);

            var result = AddOne(digits);

            Console.WriteLine("\nArray after one added:");
            ArrayHelper.Print(result);
        }

        /// <summary>
        /// Adds one to integer representaion and create new representaion as an array
        /// </summary>
        /// <param name="digits">
        /// Constraints:
        /// 1 <= digits.length <= 100
        /// 0 <= digits[i] <= 9
        /// </param>
        /// <example>
        /// Input: digits = [1,2,3]
        /// Output: [1,2,4]
        /// Explanation: The array represents the integer 123.
        /// </example>
        /// <returns>New array that represents new integer as old integer plus one</returns>
        private int[] AddOne(int[] digits)
        {
            // starting from the end of the array add one
            var newDigits = new int[digits.Length];
            var addon = 1;
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                var current = digits[i];
                if (current < 0 || current > 9)
                {
                    throw new ArgumentOutOfRangeException("Element at " + i.ToString() + " position is out of range");
                }

                newDigits[i] = current + addon;
                if (newDigits[i] > 9)
                {
                    addon = 1;
                    newDigits[i] = 0;
                }
                else
                {
                    addon = 0;
                }
            }

            if (addon == 0)
            {
                return newDigits;
            }

            // new array length is greater than old one
            // example: old array [9, 9] and new array should be [1, 0, 0]
            var result = new int[newDigits.Length + 1];
            result[0] = addon;
            for (var i = 0; i < newDigits.Length; i ++)
            {
                result[i + 1] = newDigits[i];
            }

            return result;
        }
    }
}
