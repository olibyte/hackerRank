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

    // Complete the checkMagazine function below.
    static void checkMagazine(string[] magazine, string[] note)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        for (int i = 0; i < magazine.Length; i++)
        {
            if (dic.ContainsKey(magazine[i]))
            {
                dic[magazine[i]]++;
            }
            else
            {
                dic[magazine[i]] = 1;
            }
        }
        for (int i = 0; i < note.Length; i++)
        {
            if (!dic.ContainsKey(note[i]))
            {
                Console.WriteLine("No");
                return;
            }

            dic[note[i]]--;
            if (dic[note[i]] == 0)
            {
                dic.Remove(note[i]);
            }
        }
        Console.WriteLine("Yes");

    }

    static void Main(string[] args)
    {
        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        string[] magazine = Console.ReadLine().Split(' ');

        string[] note = Console.ReadLine().Split(' ');

        checkMagazine(magazine, note);
    }
}
