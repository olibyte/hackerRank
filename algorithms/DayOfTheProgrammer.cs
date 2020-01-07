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
    // Complete the dayOfProgrammer function below.
    static string dayOfProgrammer(int year)
    {
        int daysToAdjust = 255;

        if (year == 1918)
        {
            daysToAdjust += 13;
        }
        else if (year < 1918)
        {
            if (year % 4 == 0 && year % 100 == 0)
            {
                daysToAdjust--;
            }
        }

        DateTime date = new DateTime(year, 1, 1);
        DateTime dayOfProgrammer = date.AddDays(daysToAdjust);
        return dayOfProgrammer.ToString("dd.MM.yyyy");
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = dayOfProgrammer(year);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
