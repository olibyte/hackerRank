using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class InsertionSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int n = sequence.Length;
            for (int i = 1; i < n; ++i)
            {
                K key = sequence[i];
                int j = i;

                // Move elements of arr[0..i-1]  that are greater than key, 
                //to one position ahead of their current position 
                while ((j > 0) && (comparer.Compare(sequence[j-1], key) > 0))
                {
                    sequence[j] = sequence[j-1];
                    j--;
                }
                sequence[j] = key;
            }
        }
    }
}
