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

    // Complete the sherlockAndAnagrams function below.
    static int sherlockAndAnagrams(string s)
    {
        int result = 0;
        var dict = new Dictionary<string, int>();

        for (var j = 1; j < s.Length; j++)
        {
            for (var i = 0; i < s.Length - j + 1; i++)
            {
                String t = s.Substring(i, j);
                String key = String.Concat(t.OrderBy(c => c));
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, 1);
                }
                else
                {
                    result += dict[key];
                    dict[key] += 1;
                }

                System.Console.WriteLine(key + "-" + dict[key]);

            }
        }
        return result;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}