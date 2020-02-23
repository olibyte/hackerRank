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

    // Complete the substrCount function below.
    static long substrCount(int n, string s) {
        long count = 0;
        for(int i = 0; i < s.Length; i++)
        {
            int innerCounter = 1;

            int counterDown = 0;
            int counterUp = 1;
            while(i - innerCounter >= 0 && i + innerCounter < s.Length
            && s[i-innerCounter] == s[i-1] && s[i+innerCounter] == s[i-1])
            {
                count++;
                innerCounter++;
            }
            while(i - counterDown >= 0 && i + counterUp < s.Length
            && s[i-counterDown] == s[i] && s[i+counterUp] == s[i])
            {
                count++;
                counterDown++;
                counterUp++;
            }
        }
        return count + s.Length;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        long result = substrCount(n, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
