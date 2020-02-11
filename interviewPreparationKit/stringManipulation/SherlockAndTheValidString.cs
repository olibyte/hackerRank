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

    // Complete the isValid function below.
    static string isValid(string s)
    {
        var frequencies = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            var ch = s[i];
            if (frequencies.ContainsKey(ch))
            {
                frequencies[ch]++;
            }
            else
            {
                frequencies.Add(ch, 1);
            }
        }

        var mostCommonFrequency = frequencies
            .GroupBy(f => f.Value)
            .Select(g => new { Frequency = g.Key, Count = g.Count() })
            .OrderByDescending(c => c.Count)
            .FirstOrDefault()
            .Frequency;

        var isValid = true;
        var hasSingleDifference = false;
        foreach (var frequency in frequencies)
        {
            if (frequency.Value != mostCommonFrequency)
            {
                if (hasSingleDifference || frequency.Value > mostCommonFrequency + 1)
                {
                    isValid = false;
                    break;
                }

                hasSingleDifference = true;
            }
        }


        return isValid ? "YES" : "NO";

    }
    /*--------------simpler solution-----------*/
    //     static string isValid(string s) {
    //   var dict = new Dictionary<char, int>();

    //     foreach(var c in s)
    //     {
    //         if(dict.ContainsKey(c))
    //         {
    //             dict[c] += 1;
    //         }
    //         else
    //         {
    //             dict.Add(c, 1);
    //         }
    //     }



    //     int gap = 0;
    //     int common = 0;
    //     foreach(var key in dict.Keys)
    //     {
    //         if(common == 0)
    //         {
    //             common = dict[key];
    //         }
    //         else{
    //             if(Math.Abs(dict[key] - common) > 1 && dict[key] != 1)
    //             {
    //                 return "NO";
    //             }
    //             else if(Math.Abs(dict[key] - common) == 1 || dict[key] == 1)
    //             {
    //                 gap++;
    //                 if(gap > 1)
    //                 {
    //                     return "NO";
    //                 }
    //             }
    //         }

    //     }

    //     return "YES";

    // }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = isValid(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
