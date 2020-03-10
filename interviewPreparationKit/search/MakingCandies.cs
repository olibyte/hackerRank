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

    // Complete the minimumPasses function below.
    //     m: long integer, the starting number of machines
    // w: long integer, the starting number of workers
    // p: long integer, the cost of a new hire or a new machine
    // n: long integer, the number of candies to produce
    static long minimumPasses(long m, long w, long p, long n)
    {
        long passes = 0;
        long candies = 0;
        long run = long.MaxValue;
        long step;

        while (candies < n)
        {
            step = (m > long.MaxValue / w) ? 0 : (p - candies) / (m * w);

            if (step <= 0)
            {
                long improvementUnits = candies / p;

                if (m >= w + improvementUnits)
                {
                    w += improvementUnits;
                }
                else if (w >= m + improvementUnits)
                {
                    m += improvementUnits;
                }
                else
                {
                    long total = m + w + improvementUnits;
                    m = total / 2;
                    w = total - m;
                }

                candies %= p;
                step = 1;
            }

            passes += step;

            if (step * m > long.MaxValue / w)
            {
                candies = long.MaxValue;
            }
            else
            {
                candies += step * m * w;
                run = Math.Min(run, (long)(passes + Math.Ceiling((n - candies) / (m * w * 1.0))));
            }
        }

        return Math.Min(passes, run);
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] mwpn = Console.ReadLine().Split(' ');

        long m = Convert.ToInt64(mwpn[0]);

        long w = Convert.ToInt64(mwpn[1]);

        long p = Convert.ToInt64(mwpn[2]);

        long n = Convert.ToInt64(mwpn[3]);

        long result = minimumPasses(m, w, p, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
