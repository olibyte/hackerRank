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

    // Complete the birthday function below.
    static int birthday(List<int> s, int d, int m)
    {
        int result = 0;

        for (int i = 0; i < s.Count; i++)
        {
            //prevent array index out of bounds error.
            if (i + m > s.Count) { break; }
            //no. of ways chocolate can be shared
            int sum = s[i];
            for (int j = 1; j < m; j++)
            {
                sum += s[i + j];
            }
            //if sum is equal to d, increment the integer that stores the number of ways chocolate can be shared with Ron.
            if (sum == d) { result++; }
        }
        //number of ways we can satisfy constraint
        return result;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        string[] dm = Console.ReadLine().TrimEnd().Split(' ');

        int d = Convert.ToInt32(dm[0]);

        int m = Convert.ToInt32(dm[1]);

        int result = birthday(s, d, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
