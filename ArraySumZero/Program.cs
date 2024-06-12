using System.Numerics;

namespace ArraySumZero
{
    enum ReturnCodes
    {
        SUCCESS,
        INVALID_INPUT
    }
    internal class Program
    {
        static int Main()
        {
            static bool IsLengthValid(int length)
            {
                if (length > 0 && length < 1001)
                {
                    return true;
                }
                return false;
            }

            static bool IsInputAnInt(string input)
            {
                try
                {
                    int number = Convert.ToInt32(input);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            static bool IsInputValid(string userInput)
            {
                if (IsInputAnInt(userInput))
                {
                    if (IsLengthValid(Convert.ToInt32(userInput)))
                    {
                        return true;
                    }
                }
                return false;
            }

            static List<int> CreateList(int length)
            {
                var zeroList = new List<int>();

                for (int i = 0; i < length; i++)
                {
                    zeroList.Add(0);
                }

                return zeroList;
            }

            static List<int> MakeZeroSumList(List<int> list, int length)
            {
                int index = 0;

                for (int number = -((length / 2)); index < length; number ++)
                {
                    if (index == ((length / 2)) && (length % 2 == 1))
                    {
                        index++;
                        continue;
                    }

                    if (index == (length / 2) && (length % 2 == 0))
                    {
                        number++;
                    }

                    list[index] = number;
                    index++;
                }

                return list;
            }

            static int[] FindArraySumZero(int length)
            {
                List<int> intList = CreateList(length);

                return MakeZeroSumList(intList, length).ToArray();

            }

            static void DisplayArray(int[] arr, int length)
            {
                Console.WriteLine($"An array of length {length} in which the sum is zero:");
                Console.Write("[ ");

                for (int i = 0; i < length; i++)
                {
                    if (!(i + 1 == length))
                    {
                        Console.Write($"{arr[i]}, ");
                        continue;
                    }
                    Console.Write($"{arr[i]} ]");
                }

                Console.WriteLine();
                Console.WriteLine($"The sum of the numbers in the array is {arr.Sum()}.");
            }

            Console.WriteLine("Enter an array's length: ");
            string? userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput) || !IsInputValid(userInput))
            {
                Console.WriteLine("Your input is not valid.");
                return (int)ReturnCodes.INVALID_INPUT;
            }

            int arrayLength = Convert.ToInt32(userInput);

            int[] resultArray = FindArraySumZero(arrayLength);
            DisplayArray(resultArray, arrayLength);

            return (int)ReturnCodes.SUCCESS;
        }
    }
}
