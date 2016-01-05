using System;
using System.Linq;

namespace RecursiveAlternatives
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] {1,2,3};

            Console.WriteLine(RecursiveWithOptionalCounterParameter(numbers));

            Console.WriteLine(RecursiveWithCounterParameter(numbers,0));

            int count =0;
            Console.WriteLine(RecursiveWithReferenceCounterParameter(numbers,ref count));

            Console.WriteLine(RecursiveWithNoCounterParameter(numbers));

            Console.ReadKey();
        }

        /// <summary>
        /// This uses a optional counter variable to keep track of index.
        /// So its the counter that changes.
        /// This version returns sum of numbers[0] + numbers[1] + numbers[2] + 0
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="count"></param>
        /// <returns>int sum of numbers</returns>
        static int RecursiveWithOptionalCounterParameter(int[] numbers, int count = 0)
        {            
            if (numbers.Length < 1||numbers.Length==count)
            {
                return 0;
            }
            else {
                return numbers[count] + RecursiveWithOptionalCounterParameter(numbers,count+1);
            }
        }

        /// <summary>
        /// This uses a counter variable to keep track of index.
        /// So its the counter that changes.
        /// This version returns sum of numbers[0] + numbers[1] + numbers[2] + 0
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="count"></param>
        /// <returns>int sum of numbers</returns>
        static int RecursiveWithCounterParameter(int[] numbers, int count)
        {
                if (numbers.Length < 1 || numbers.Length==count)
                {
                    return 0;
                }
                else {
                    return numbers[count] + RecursiveWithCounterParameter(numbers, count + 1);
                }

               // Compact version
               //return (numbers.Length < 1 || numbers.Length == count) ? 0 : numbers[count] + Recursive1(numbers, count + 1);
        }

        /// <summary>
        /// This uses a counter variable to keep track of index.
        /// The variable is of type ref, useful to keep track from outside the method.
        /// So its the counter that changes.
        /// This version returns sum of numbers[0] + numbers[1] + numbers[2] + 0
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="count"></param>
        /// <returns>int sum of numbers</returns>
        static int RecursiveWithReferenceCounterParameter(int[] numbers, ref int count)
        {
            if (numbers.Length < 1 || numbers.Length == count)
            {
                return 0;
            }
            else {
                int countIncrement = count;
                countIncrement++;
                return numbers[count] + RecursiveWithReferenceCounterParameter(numbers, ref countIncrement);
            }
        }

        /// <summary>
        /// This version reduces the size of the array in each method call.
        /// Therefor index of 0 value number will be different each time.
        /// Its the array that changes. Not a counter.
        /// This version returns sum of numbers[0] + numbers[0] + numbers[0] + 0
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>int sum of numbers</returns>
        static int RecursiveWithNoCounterParameter(int[] numbers)
        {
            if (numbers.Length < 1 || numbers.Length == 0)
            {
                return 0;
            } else
            {
                int[] reducedArray = new ArraySegment<int>(numbers, 1, numbers.Length - 1).ToArray<int>();
                return numbers[0] + RecursiveWithNoCounterParameter(reducedArray);
            }
        }


    }
}
