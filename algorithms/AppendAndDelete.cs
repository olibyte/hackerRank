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

    // Complete the appendAndDelete function below.
    static string appendAndDelete(string s, string t, int k) {
            int commonLength = GetCommonLength(s, t);
            int totalLength = s.Length + t.Length;
            int totalMinusCommonLength = totalLength - 2 * commonLength;

            // Case 1
            if (totalMinusCommonLength > k)
            {
                return "No";
            }

            // Case 2
            if ((totalMinusCommonLength - k) % 2 == 0)
            {
                return "Yes";
            }

            // Case 3
            if (totalLength - k < 0)
            {
                return "Yes";
            }

            // Case 4
            return "No";
        }

        static int GetCommonLength(string s1, string s2)
        {
            int commonLength = 0;
            int len1 = s1.Length;
            int len2 = s2.Length;
            int len = len1 >= len2 ? len2 : len1;

            for (int n = 0; n < len; n++)
            {
                if (s1[n] == s2[n])
                {
                    commonLength++;
                }
                else
                {
                    break;
                }
            }

            return commonLength;
        }


    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string t = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine());

        string result = appendAndDelete(s, t, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }

}