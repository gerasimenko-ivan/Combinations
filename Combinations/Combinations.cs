using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Combinations
{
    public static class Combinations
    {
        public static int[][] Get(int[] array, int k)
        {
            return Get<int>(array, k);
        }
        public static double[][] Get(double[] array, int k)
        {
            return Get<double>(array, k);
        }
        public static T[][] Get<T>(T[] array, int k)
        {
            if (k < 1 || k > array.Length)
            {
                throw new ArgumentOutOfRangeException(
                    "Argument k cannot be greater then length of array and less then one.");
            }
            List<T[]> combinations = new List<T[]>();
            T[] combination = new T[k];
            int[] indicesInArrayForSubset = new int[k];
            for (int i = 0; i < k; i++)
            {
                indicesInArrayForSubset[i] = i;
            }

            /* iterative right-to-left search through current set of indices
             * for the rightmost to be changed (by adding 1) by the condition
             * Index != (n-IndexPosition), where n+1 is the length of array.
             * All indices that are to the right side from the found index are
             * also changed by equating to [the leftside index + 1].
             * E.g. current situation is:
             * subset 0,k,n-2,n-3,n-4 (where 0<k<{n-3}) so
             * index to be changet is k and all indices on the right side
             * after changes: 0,k+1,k+2,k+3,k+4.
             * 
             * So indices are changed as follows (k=5, array.Length = 10:
             * from {0,1,2,3,4} -> {0,1,2,3,5} -> {0,1,2,3,6} -...-> {0,1,2,3,9}->
             * {0,1,2,4,5} -> {0,1,2,4,6} -...-> 
             * and finally comes to {5,6,7,8,9}
             * */
            for (; ; )
            {
                for (int i = 0; i < k; i++)
                {
                    combination[i] = array[indicesInArrayForSubset[i]];
                }
                combinations.Add(new T[k]);
                Array.Copy(combination, combinations[combinations.Count - 1], k);
                for (int i = k - 1; i >= -1; i--)
                {
                    // all the combinations were found
                    if (i == -1)
                        goto END_LOOP;

                    if (indicesInArrayForSubset[i] != array.Length - (k - i))
                    {
                        indicesInArrayForSubset[i]++;
                        for (int j = i + 1; j < k; j++)
                        {
                            indicesInArrayForSubset[j] = indicesInArrayForSubset[j - 1] + 1;
                        }
                        break;
                    }
                }
            }
        END_LOOP:

            return combinations.ToArray();
        }
    }
}
