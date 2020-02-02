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

    // Complete the makeAnagram function below.
    static int makeAnagram(string a, string b)
    {
        //convert both words to lists of letters
        List<string> A = a.Select(x => x.ToString()).ToList();
        List<string> B = b.Select(x => x.ToString()).ToList();
        int count = 0;
        bool flag;

        foreach (var itemA in A)
        {
            flag = true;
            foreach (var itemB in B)
            {
                if (itemA == itemB)
                {
                    B.Remove(itemB);
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                count++;
            }
        }

        count += B.Count(); //count the number of characters left in B.

        return count;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string a = Console.ReadLine();

        string b = Console.ReadLine();

        int res = makeAnagram(a, b);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
