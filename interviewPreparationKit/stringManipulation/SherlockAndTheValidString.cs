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
