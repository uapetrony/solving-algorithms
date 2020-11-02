using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Mathematics
{
    /// <summary>
    /// Given an integer, write a function to determine if it is a power of three.
    /// </summary>
    /// <remarks>
    /// https://leetcode.com/explore/interview/card/top-interview-questions-easy/102/math/745/
    /// </remarks>
    public class PowerOfThree
    {
        /// <summary>
        /// Run with test data in place
        /// </summary>
        public void Run()
        {
            var n = 2_147_483_647;
            Run(n);
        }

        /// <summary>
        /// Run algorithm and print result 
        /// </summary>
        public void Run(int n)
        {
            var result = IsPowerOfThree(n);
            Console.WriteLine($"{n} is power of three: {result}");
        }

        /// <summary>
        /// Defines if integer is power of 3
        /// </summary>
        /// <example>
        /// Input: 27
        /// Output: true
        /// 
        /// Input: 45
        /// Output: false
        /// </example>
        private bool IsPowerOfThree(int n)
        {
            if (n < 1 || n == 2)
            {
                return false;
            }
            else if (n == 1 || n == 3)
            {
                // every number in power of zero equals one
                return true;
            }

            
            var multiplication = 3;
            try
            {
                checked
                {
                    while (multiplication < n)
                    {
                        multiplication *= 3;
                    }
                }
            }
            catch (OverflowException)
            {
                // we've done with multiplying an integer
            }
            
            return multiplication == n;
        }
    }
}
