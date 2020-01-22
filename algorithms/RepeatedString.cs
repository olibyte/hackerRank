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

    // Complete the repeatedString function below.
    static long repeatedString(string s, long n) {
            long totalRepetitionCount = 0;
            long remainingLength = 0;

            totalRepetitionCount = n / s.Length;
            remainingLength = n % s.Length;

            return remainingLength == 0 ? totalRepetitionCount * GetCount(s) : totalRepetitionCount * GetCount(s) + GetCount(s, remainingLength);
        }

        static long GetCount(string s)
        {
          long count = 0;
          foreach(char c in s)
          {
              if(c == 'a')
              {
                  count++;
              }
          }
          return count;
        }

        static long GetCount(string s, long n)
        {
          long count = 0;
          for(int i = 0; i < n; i++)
          {
              if(s[i] == 'a')
              {
                  count++;
              }
          }
          return count;
        }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine());

        long result = repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
