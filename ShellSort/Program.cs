using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ShellSort
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 100;
            int[] a = new int[N];
            Random r = new Random();

            for (int i = 0; i < N; i++)
            {
                a[i] = r.Next(1, N + 1);
            }

            // display unsorted list
            WriteLine("Unsorted: ");
            foreach (int i in a)
            {
                Write(i + " ");
            }

            WriteLine();

            // call sort routine        
            //ShellSort(a, N);
            ShellSort(a, N);
            //SpecialInsertionSort(testArray, N, testArray[0], testArray[N-1]);

            // display sorted list
            WriteLine("Sorted: ");
            foreach (int i in a)
            {
                Write(i + " ");
            }

            WriteLine();
            ReadLine();
        }

        static void ShellSort(int[] list, int N)
        // list: Number of elements to be put into order
        // N: the number of elements in the list
        {
            int passes = Convert.ToInt32(Math.Log(N));
 
            while (passes >= 0)
            {
                int increment = (2 ^ passes) - 1;

                //for (int start = 0; (start < increment) && (increment >= passes); start++)
                for(int start = 0; start < N; start++)

                {
                    SpecialInsertionSort(list, N, start, increment);
                }   // end for

                passes = passes - 1;
            }   // end while
        }

        static void SpecialInsertionSort(int[] list, int N, int start, int increment)
            // list: number of elements to be put into order
            // N: number of elements in the list
            // start: starting location in the list
            // increment: ending location in the list
        {
            int newElement = list[start];
            int location = start;

            for(int i = 0; i < increment; i++)
            {
                while ((location >= increment) && (list[(location - increment)] > newElement))
                {
                    list[location] = list[location - increment];
                    location = location - increment;
                }   // end while

                list[location] = newElement;
            }   // end for
        }
    }
}
