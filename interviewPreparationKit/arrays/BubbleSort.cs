using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the countSwaps function below.
    static void countSwaps(int[] a) {
        int swaps = 0;
        bool isSorted = false;
        int size = a.Length;
        int lastUnsorted = size -1;

        while(!isSorted)
        {
            isSorted = true;
            for(int n = 0; n < lastUnsorted; n++)
            {
                if(a[n] > a[n+1])
                {
                    swaps++;
                    int temp = a[n];
                    a[n] = a[n+1];
                    a[n+1] = temp;
                    isSorted = false;
                }
            }
            lastUnsorted--;
        }
        Console.WriteLine("Array is sorted in "+swaps+" swaps.");
        Console.WriteLine("First Element: " + a[0]);
        Console.WriteLine("Last Element: " + a[size-1]);
    }

    static void Main(string[] args) {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;
        countSwaps(a);
    }
}