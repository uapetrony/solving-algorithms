namespace LeetCode.Arrays;

/// <summary>
/// You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
/// You have to rotate the image in-place, which means you have to modify the input 2D matrix directly.DO NOT allocate another 2D matrix and do the rotation.
/// </summary>
/// <remarks>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/770/
/// </remarks>
public class RotateImage
{
    /// <summary>
    /// Run with test data in place
    /// </summary>
    public void Run()
    {
        var matrix = new int[3][];
        matrix[0] = new int[] { 1, 2, 3 };
        matrix[1] = new int[] { 4, 5, 6 };
        matrix[2] = new int[] { 7, 8, 9 };
        Run(matrix);
    }

    /// <summary>
    /// Calculate and print result 
    /// </summary>
    /// <param name="sortedArray"></param>
    public static void Run(int[][] matrix)
    {
        Console.WriteLine("Initial array:");
        foreach (int[] row in matrix)
        {
            ArrayHelper.Print(row, " ");
            Console.WriteLine();
        }
        
        Rotate(matrix);

        Console.WriteLine($"\nRotated:");
        foreach (int[] row in matrix)
        {
            ArrayHelper.Print(row, " ");
            Console.WriteLine();
        }
    }

    /// <summary>
    /// n == matrix.length == matrix[i].length
    /// 1 <= n <= 20
    /// -1000 <= matrix[i][j] <= 1000
    /// </summary>
    /// <param name="matrix"></param>
    private static void Rotate(int[][] matrix)
    {
        var length = matrix.Length;
        // switch cells by group of four
        // example for 3x3:
        // n[0][0] => n[0][2] => n[2][2] => n[2][0] => n[0][0]
        // n[0][1] => n[1][2] => n[2][1] => n[1][0] => n[0][1]
        for (var i = 0; i < (length + 1) / 2; i++)
        {
            for (var j = 0; j < length / 2; j++)
            {
                var temp = matrix[length - j - 1][i];
                matrix[length - j - 1][i] = matrix[length - i - 1][length - j - 1];
                matrix[length - i - 1][length - j - 1] = matrix[j][length - i - 1];
                matrix[j][length - i - 1] = matrix[i][j];
                matrix[i][j] = temp;
            }
        }
    }
}
