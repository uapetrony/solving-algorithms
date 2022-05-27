namespace LeetCode.Arrays;

/// <summary>
/// Say you have an array prices for which the ith element is the price of a given stock on day i.
/// Design an algorithm to find the maximum profit.
/// You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).
/// Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).
/// </summary>
/// <remarks>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/564/
/// </remarks>
public class BestTimeToBuyAndSellStock
{
    /// <summary>
    /// Run with test data in place
    /// </summary>
    public void Run()
    {
        var prices = new int[] { 7, 1, 5, 3, 6, 4 };
        Run(prices);
    }

    public void Run(int[] prices)
    {
        Console.WriteLine("Initial array:");
        ArrayHelper.Print(prices);

        var maxOutcome = MaxProfit(prices);

        Console.WriteLine("\nOutcome: " + maxOutcome.ToString());
    }

    /// <summary>
    /// Returns max outcome from give prices array
    /// </summary>
    /// <param name="prices">Prices array where every element represents price on a separate day</param>
    /// <example>
    /// Input: [7,1,5,3,6,4]
    /// Output: 7
    /// Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
    ///     Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
    /// Input: [1,2,3,4,5]
    /// Output: 4
    /// Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
    ///     Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are
    ///     engaging multiple transactions at the same time.You must sell before buying again.
    /// </example>
    /// <returns></returns>
    private static int MaxProfit(int[] prices)
    {
        if (prices == null)
        {
            throw new ArgumentNullException("Array with prices cannot be null");
        }

        if (prices.Length <= 1)
        {
            return 0;
        }

        // the idea is just find all sequences where:
        // a price changes to the bigger one - this is time to buy
        // a price changes to the smaller one, this is time to sell
        var outcome = 0;

        for (var indexToBuy = 0; indexToBuy < prices.Length - 1;)
        {
            var indexToSell = indexToBuy + 1;
            if (prices[indexToBuy] > prices[indexToSell])
            {
                indexToBuy++;
                continue;
            }

            indexToSell = GetIndexToSell(prices, indexToSell);
            outcome += prices[indexToSell] - prices[indexToBuy];

            indexToBuy = indexToSell + 1;
        }

        return outcome;
    }

    /// <summary>
    /// Gets an index for the most profitable operation
    /// </summary>
    private static int GetIndexToSell(int[] prices, int startIndex)
    {
        var resultIndex = startIndex;
        var nextIndex = startIndex + 1;

        // start looking the greatest number in the following sequence
        while (resultIndex < prices.Length - 1 && prices[resultIndex] <= prices[nextIndex])
        {
            resultIndex++;
            nextIndex++;
        }

        return resultIndex;
    }
}