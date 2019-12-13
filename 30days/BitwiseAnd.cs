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

class Solution
{



    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        int[] n = new int[t];

        int[] k = new int[t];


        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] nk = Console.ReadLine().Split(' ');

            n[tItr] = Convert.ToInt32(nk[0]);

            k[tItr] = Convert.ToInt32(nk[1]);
        }

        for (int i = 0; i < t; i++)
        {
            CalculateAND(n[i], k[i]);
        }
    }

    static void CalculateAND(int n, int k)
    {
        if ((k - 1 | k) <= n)
        {
            Console.WriteLine(k - 1);
        }
        else
        {
            Console.WriteLine(k - 2);
        }
    }
}
