using System;
using System.Collections.Generic;
using System.Linq;

namespace Vector
{
    public class MergeSortBottomUp : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            MergeSort(sequence, comparer);
        }

        private void MergeSort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int n = sequence.Length;
            K[] src = sequence;     //alias for original sequence
            K[] dest = new K[n];    //new temporary array

            for (int i = 1; i < n; i *= 2)  //iteration sorts all runs of length i
            {
                for (int j = 0; j < n; j += 2*i) //each pass merges two runs of length i
                {
                    Merge(src, dest, comparer, j, i);
                }
                Swap(ref src, ref dest);    //reverse roles of vectors
            }
            if(sequence != src)
            {
                Array.Copy(src, 0, sequence, 0, n); //additional copy to get result to original sequence
            }

        }

        private void Swap<K>(ref K[] A, ref K[] B) where K : IComparable<K>
        {
            K[] Temp;
            Temp = B;
            A = B;
            B = Temp;
        }

        private void Merge<K>(K[] In, K[] Out, IComparer<K> comparer, int start, int inc) where K : IComparable<K>
        {
            //Merges in[start...start+inc-1] and in[start+inc...start+2*inc-1] into out
            int end1 = Math.Min(start + inc, In.Length);        //boundary for run 1
            int end2 = Math.Min(start + 2 * inc, In.Length);    //boundary for run 2
            int x = start;                                      //index into run 1
            int y = start + inc;                                //index into run 2
            int z = start;                                      //index into output

            while (x < end1 && y < end2)
            {
                if (comparer.Compare(In[x], In[y]) < 0)
                    {
                    Out[z++] = In[x++];     //take next from run 1
                }
                else
                {
                    Out[z++] = In[y++];     //take next from run 2
                }
            }
            if (x < end1)
            {

                Array.Copy(In, x, Out, z, end1 - x);                    //copy rest of run 1
            }
            else if (y < end2) Array.Copy(In, y, Out, z, end2 - y);     //copy rest of run 2
        }
    }
}
