namespace LeetCode.Arrays;

/// <summary>
/// Determine if a 9 x 9 Sudoku board is valid
/// </summary>
/// <remarks>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/769/
/// </remarks>
public class ValidSudoku
{
    private static readonly char[] _chars = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    /// <summary>
    /// Run with test data in place
    /// </summary>
    public void Run()
    {
        var validBoard = new char[9][];
        validBoard[0] = new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' };
        validBoard[1] = new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
        validBoard[2] = new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
        validBoard[3] = new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
        validBoard[4] = new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
        validBoard[5] = new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
        validBoard[6] = new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
        validBoard[7] = new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' };
        validBoard[8] = new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' };

        Run(validBoard);

        var invalidboard = new char[9][];
        invalidboard[0] = new char[] { '.', '.', '4', '.', '.', '.', '6', '3', '.' };
        invalidboard[1] = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };
        invalidboard[2] = new char[] { '5', '.', '.', '.', '.', '.', '.', '9', '.' };
        invalidboard[3] = new char[] { '.', '.', '.', '5', '6', '.', '.', '.', '.' };
        invalidboard[4] = new char[] { '4', '.', '3', '.', '.', '.', '.', '.', '1' };
        invalidboard[5] = new char[] { '.', '.', '.', '7', '.', '.', '.', '.', '.' };
        invalidboard[6] = new char[] { '.', '.', '.', '5', '.', '.', '.', '.', '.' };
        invalidboard[7] = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };
        invalidboard[8] = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };

        Run(invalidboard);
    }

    /// <summary>
    /// Calculate and print result 
    /// </summary>
    /// <param name='sortedArray'></param>
    public static void Run(char[][] board)
    {
        Console.WriteLine("Initial board:");
        foreach (var arr in board)
        {
            ArrayHelper.Print(arr);
        }


        var isValid = IsValidSudoku(board);

        Console.WriteLine($"\nSudoku is valid: {isValid}");
    }

    /// <summary>
    /// Each row must contain the digits 1-9 without repetition.
    /// Each column must contain the digits 1-9 without repetition.
    /// Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
    /// A Sudoku board (partially filled) could be valid but is not necessarily solvable.
    /// Only the filled cells need to be validated according to the mentioned rules.
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    private static bool IsValidSudoku(char[][] board)
    {
        // columns
        foreach (var num in _chars)
        {
            for (var colIndex = 0; colIndex < 9; colIndex++)
            {
                var isPresentInColumn = false;
                foreach (var arr in board)
                {
                    if (arr[colIndex] == num)
                    {
                        if (isPresentInColumn)
                        {
                            return false;
                        }

                        isPresentInColumn = true;
                    }
                }
            }
        }

        // rows
        var duplicateMap = new HashSet<char>(9);
        foreach (var row in board)
        {
            foreach (var cell in row)
            {
                if (cell == '.')
                {
                    continue;
                }

                if (duplicateMap.Contains(cell))
                {
                    return false;
                }
                else
                {
                    duplicateMap.Add(cell);
                }
            }

            duplicateMap.Clear();
        }

        // blocks
        for (var yshift = 0; yshift < 9; yshift += 3)
        {
            for (var xshift = 0; xshift < 9; xshift += 3)
            {
                for (var i = 0; i < 3; i++)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        var cell = board[i + yshift][j + xshift];

                        if (cell == '.')
                        {
                            continue;
                        }

                        if (duplicateMap.Contains(cell))
                        {
                            return false;
                        }
                        else
                        {
                            duplicateMap.Add(cell);
                        }
                    }
                }

                duplicateMap.Clear();
            }
        }

        return true;
    }
}
