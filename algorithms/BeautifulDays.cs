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

    // Complete the beautifulDays function below.
    static int beautifulDays(int i, int j, int k)
    {
        int x = i - j;
        int beautifulDays = 0;
        while (i <= j)
        {
            int reverse = Reverse(i);
            int rNumber = Math.Abs(i - reverse);
            var numberCheck = rNumber % k;
            if (numberCheck == 0)
            {
                beautifulDays++;
                i++;
            }
            else
            {
                i++;
            }
        }
        return beautifulDays;


    }
    private static int Reverse(int n)
    {
        int left = n;
        int rev = 0;
        while (left > 0)
        {
            int r = left % 10;
            rev = rev * 10 + r;
            left = left / 10;
        }
        return rev;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] ijk = Console.ReadLine().Split(' ');

        int i = Convert.ToInt32(ijk[0]);

        int j = Convert.ToInt32(ijk[1]);

        int k = Convert.ToInt32(ijk[2]);

        int result = beautifulDays(i, j, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
