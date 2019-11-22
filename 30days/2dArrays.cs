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
        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++) {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }
        int top = 0;
            int middle = 0;
            int bottom = 0;
            int counter = 0;
            List<int> counts = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    top = arr[i][j] + arr[i][j + 1] + arr[i][j + 2];
                    middle = arr[i + 1][j + 1];
                    bottom = arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                    counter = top + middle + bottom;
                    counts.Add(counter);
                }
            }
            counts.Sort();
            counts.Reverse();

            Console.Write("{0}", counts[0]);

    }
}
