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

    // Complete the luckBalance function below.
    static int luckBalance(int k, int[][] contests)
    {
        List<int> important = new List<int>();
        int luckbalance = 0;
        for (int i = 0; i < contests.Length; i++)
        {
            int luck = contests[i][0];
            luckbalance = luckbalance + luck;

            int importance = contests[i][1];
            if (importance == 1)
                important.Add(luck);
        }

        if (important.Count > k)
        {
            important.Sort();
            int n = important.Count - k;
            for (int i = 0; i < n; i++)
            {
                luckbalance = luckbalance - 2 * important[i];
            }
        }

        return luckbalance;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[][] contests = new int[n][];

        for (int i = 0; i < n; i++)
        {
            contests[i] = Array.ConvertAll(Console.ReadLine().Split(' '), contestsTemp => Convert.ToInt32(contestsTemp));
        }

        int result = luckBalance(k, contests);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
