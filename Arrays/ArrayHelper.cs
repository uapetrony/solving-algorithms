namespace LeetCode.Arrays;

public static class ArrayHelper
{
    public static void Print<T>(T[] array)
    {
        Print<T>(array, "\n", array == null ? 0 : array.Length);
    }

    public static void Print<T>(T[] array, int elementsCount)
    {
        Print<T>(array, "\n", elementsCount);
    }

    public static void Print<T>(T[] array, string separator)
    {
        Print<T>(array, separator, array == null ? 0 : array.Length);
    }

    public static void Print<T>(T[] array, string separator, int elementsCount)
    {
        if (array == null)
        {
            Console.WriteLine("Null");
            return;
        }

        var countToPrint = Math.Min(array.Length, elementsCount);

        switch (countToPrint)
        {
            case 0:
                Console.Write("Empty");
                break;
            case 1:
                Console.Write(array[0]);
                break;
            default:
                {
                    for (var i = 0; i < countToPrint - 1; i++)
                    {
                        Console.Write(array[i].ToString() + separator);
                    }
                    Console.Write(array[^1].ToString());
                    break;
                }
        }
    }
}