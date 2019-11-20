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

    static void Main(string[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
            int i = 0, k=0;
            int count = 0; 
            // array contain the binary 
            int[] a= new int[100] ;
            while (n > 0)
            {
                a[i] = n % 2;
                n = n / 2;
                i++;
            }
         
            for (int j=0; j<a.Length; j++)
            {
                if (a[j] == 1)
                {
                    count += 1;
                }
                else
                {
                    if(count > k)
                    {
                        k = count;
                    }
                    count = 0;
                }

            }
        Console.WriteLine(k);
    }
}
