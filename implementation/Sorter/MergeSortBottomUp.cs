using System;
using System.Collections.Generic;
using System.Linq;

namespace Vector
{
    public class MergeSortBottomUp : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (comparer == null) comparer = Comparer<K>.Default;

            MergeSort(sequence, comparer);
        }
        private static void MergeSort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int n = sequence.Length;
            if (n < 2) return; //array is trivially sorted

            //divide
            int mid = n / 2;
            K[] S1 = new K[mid];
            K[] S2 = new K[mid];
            S1 = sequence.Take(mid).ToArray();
            S2 = sequence.Skip(mid).ToArray();

            //conquer
            MergeSort(S1, comparer);
            MergeSort(S2, comparer);

            //merge results
            Merge(S1, S2, sequence, comparer);
        }

        private static void Merge<K>(K[] S1, K[] S2, K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int i = 0; int j = 0;
            while (i + j < sequence.Length)
            {
                if (j == S2.Length || (i < S1.Length && comparer.Compare(S1[i], S2[j]) < 0))
                {
                    sequence[i + j] = S1[i++]; //copy ith element of S1 and increment i
                }
                else
                {
                    sequence[i + j] = S2[j++]; //copy jth element of S2 and increment j
                }
            }
        }
    }
}
