using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static int[] fibs;
        static int Triangle(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n + Triangle(n - 1);
            }
        }

        static int Factorial(int n)
        {
            if (n == 1 || n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        static int Fibonacci(int upTo, int current, int previous)
        {
            if (upTo <= 1)
            {
                return current;
            }
            else
            {   //make one recursive call instead of 2 to increase speed
                return Fibonacci(upTo - 1, current + previous, current);
            }
        }

        // MEMOIZATION Fibonacci sequence
        static int memFib(int num)
        {
            if (num == 0 || num == 1)
            {
                return 1;
            }
            if (fibs[num] != -1)
            {
                return fibs[num];
            }
            fibs[num] = memFib(num - 1) + memFib(num - 2);
            return fibs[num];
        }
        
        static string printStars(int n)
        {
            if (n <= 0)
            {
                return "";
            }
            else
            {
                string stars = printStars(n - 1);
                stars = stars + "*";
                Console.WriteLine(stars);
                return stars;
            }
        }


        static void mergeSort(int lower, int upper)
        {
            int mid;
            if (lower < upper)
            {
                mid = (lower + upper) / 2;
                mergeSort(lower, mid);
                mergeSort(mid + 1, upper);
                merge(lower, mid, upper);
            }
        }

        static int[] merge(int[] left, int[] right)
        {
            int[] sorted = new int[left.Length + right.Length];
            int leftIndex = 0;
            int rightIndex = 0;
            int sortedIndex = 0;
            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    sorted[sortedIndex] = left[leftIndex];
                    leftIndex++;
                    sortedIndex++;
                }
                else
                {
                    sorted[sortedIndex] = right[rightIndex];
                    rightIndex++;
                    sortedIndex++;
                }
            }
            return sorted;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an integer: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Triangle: " + Triangle(num));
            Console.WriteLine("Factorial: " + Factorial(num));
            Console.WriteLine("Fibonacci: " + Fibonacci(num, 1, 0));

            fibs = new int[num + 1];
            for (int i = 0; i <= num; i++)
            {
                fibs[i] = -1;
            }
            Console.WriteLine("Memoization Fibonacci: " + memFib(num));
            Console.WriteLine("Stars: " + printStars(num));
            Console.ReadKey();
            int[] toMerge = { 1, 24, 2, 5, 886, 42, 32, 8 };
            
        }
    }
}
