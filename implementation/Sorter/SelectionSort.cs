using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class SelectionSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int n = sequence.Length;

            // One by one move boundary of unsorted subarray 
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (comparer.Compare(sequence[j], sequence[min_idx]) < 0)
                    { 
                        min_idx = j;
                    }
                }
                // Swap the found minimum element with the first
                Swap(ref sequence[min_idx], ref sequence[i]);
            }
        }
        public void Swap<K>(ref K a, ref K b)
        {
            K temp;
            temp = a;
            a = b;
            b = temp;
        }
    }
}
