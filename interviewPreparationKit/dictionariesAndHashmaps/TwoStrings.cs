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

    // Complete the twoStrings function below.
    static string twoStrings(string s1, string s2) {
        Dictionary<char, int> strDictA = new Dictionary<char, int>();
        Dictionary<char, int> strDictB = new Dictionary<char, int>();
        str matchingChar = "";

        for(var i = 0; i < s1.Length; i++)
        {
            if(strDictA.ContainsKey(s1[i]))
            {
                strDictA[s1[i]] += 1;
            }
            else
            {
                strDictA.Add(s1[i], 1);
            }
        }
        for(var j = 0; j < s2.Length; j++)
        {
            if(strDictB.Contains(s2[j]))
            {
                strDictB[s2[j]] += 1;
            }
            else
            {
                strDictB.Add(s2[j], 1);
            }
        }
        foreach(var pair in strDictA)
        {
            if (strDictB.ContainsKey(pair.Key))
            {
                Console.WriteLine("Found a matching char: " + pair.Key);
                matchingChar += pair.Key;
                return "YES";
            }
            else
            {
                Console.WriteLine("No match found");
            }
        }
        Console.WriteLine("matchingChar: " + matchingChar);

        return "NO";

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            string result = twoStrings(s1, s2);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
