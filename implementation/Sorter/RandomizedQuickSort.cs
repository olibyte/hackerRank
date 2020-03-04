using System;
using System.Collections.Generic;
using System.Text;

/**optimised version of the QuickSort algorithm, selecting the pivot element uniformly at random from a range of elements
 available within a recursive call. It performs sorting operations 'in-place' (i.e. using only a small amount
    of memory in addition to that needed for the original input.
    Uses the input sequence itself to store the sub-sequences for all the recursive calls.
    In-place quick-sort modifies the input sequence using element swapping and does not explicitly create subsequences.
    Instead, a subsequence of the input sequence is implicitly represented by a range
    of positions specified by a leftmost index a and a rightmost index b.
    The divide step is performed by scanning the array simultaneously using local variables left,
    which advances forward, and right, which advances backward, swapping pairs of
    elements that are in reverse order, as shown in Figure 12.14. When these two indices
    pass each other, the division step is complete and the algorithm completes by
    recurring on these two sublists. There is no explicit “combine” step, because the
    concatenation of the two sublists is implicit to the in-place use of the original list.
    Reference: pg 533-534 Data Structures and Algorithms in Java 6th Edition **/
namespace Vector
{
    public class RandomizedQuickSort : ISorter
    {
        public void Swap<K>(ref K a, ref K b)
        {
            K temp;
            temp = a;
            a = b;
            b = temp;
        }
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (comparer == null) comparer = Comparer<K>.Default;

            QuickSortInPlace(sequence, comparer, 0, sequence.Length -1);
        }
        //sort the subarray sequence[a..b] inclusive.
        private void QuickSortInPlace <K>(K[] sequence, IComparer<K> comparer, int a, int b)
        {
            if (a >= b) return; //subarray is trivially sorted
            int left = a;
            int right = b - 1;
            K pivot = sequence[b];

            while(left <= right)
            {
                //scan until reaching value equal or larger than pivot (or right marker)
                while (left <= right && comparer.Compare(sequence[left], pivot) < 0)
                {
                    left++;
                }
                while (left <= right && comparer.Compare(sequence[right], pivot) > 0)
                {
                    //scan until reaching equal or smaller than pivot (or left marker)
                    right--;
                }
                if(left <= right) //indices did not strictly cross
                {
                    //so swap values and shrink range
                    Swap(ref sequence[left], ref sequence[right]);

                    left++; right--;
                }
            }
            //put pivot into its final place (currently marked by left index)
            Swap(ref sequence[left], ref sequence[b]);
            //make recursive calls
            QuickSortInPlace(sequence, comparer, a, left - 1);
            QuickSortInPlace(sequence, comparer, left + 1, b);
        }
    }
}
