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
    // Complete the abbreviation function below.
    public static string abbreviation(string a, string b)
    {
        Dictionary<string, string> cache = new Dictionary<string, string>();
        return InternalAbbreviation(a, 0, b, 0, cache);
    }

    private static string GetCacheKey(int aIndex, int bIndex)
    {
        return string.Format("{0}-{1}", aIndex, bIndex);
    }

    private static string InternalAbbreviation(string a, int aIndex, string b, int bIndex, Dictionary<string, string> cache)
    {
        string cacheKey = GetCacheKey(aIndex, bIndex);
        if (cache.ContainsKey(cacheKey))
        {
            return cache[cacheKey];
        }

        if (a.Length - aIndex < b.Length - bIndex)
        {
            cache[cacheKey] = "NO";
            return cache[cacheKey];
        }

        if (bIndex == b.Length)
        {
            while (aIndex < a.Length && Char.IsLower(a[aIndex]))
            {
                aIndex++;
            }

            cache[cacheKey] = aIndex == a.Length ? "YES" : "NO";
            return cache[cacheKey];
        }

        string answer = null;
        if (Char.ToUpper(a[aIndex]) == Char.ToUpper(b[bIndex]))
        {
            // same letter, case-insensitive
            if (Char.IsLower(a[aIndex]))
            {
                // same letter but lower, try dropping it
                answer = InternalAbbreviation(a, aIndex + 1, b, bIndex, cache);
            }

            if (answer != "YES")
            {
                // same letter, dropping it didn't work
                answer = InternalAbbreviation(a, aIndex + 1, b, bIndex + 1, cache);
            }
        }
        else
        {
            // different letter
            answer = Char.IsLower(a[aIndex])
                // try dropping it if it's lower
                ? InternalAbbreviation(a, aIndex + 1, b, bIndex, cache)
                // else fail
                : "NO";
        }

        cache[cacheKey] = answer;
        return cache[cacheKey];
    }

}
static void Main(string[] args)
{
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int q = Convert.ToInt32(Console.ReadLine());

    for (int qItr = 0; qItr < q; qItr++)
    {
        string a = Console.ReadLine();

        string b = Console.ReadLine();

        string result = abbreviation(a, b);

        textWriter.WriteLine(result);
    }

    textWriter.Flush();
    textWriter.Close();
}
