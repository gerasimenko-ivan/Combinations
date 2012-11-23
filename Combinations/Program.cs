using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[][] subsets = Combinations.Get(array, 4);

            for (int i = 0; i <= subsets.GetUpperBound(0); i++)
            {
                Console.Write(" {0} :: ", i);
                foreach (int intItem in subsets[i])
                    Console.Write(" {0}", intItem);
                Console.WriteLine();
            }

            Console.ReadKey(true);
        }
    }
}
