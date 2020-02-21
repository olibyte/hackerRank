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

    // Complete the activityNotifications function below.
    static int activityNotifications(int[] expenditure, int d)
    {
        var notifications = 0;
        var count = new int[201];
        var i1 = (int)Math.Floor((d - 1) / 2d);
        var i2 = (int)Math.Ceiling((d - 1) / 2d);
        for (var i = d - 1; i >= 0; i--) count[expenditure[i]]++;
        for (var i = d; i < expenditure.Length; i++)
        {
            var m = FindMedian(count, i1, i2);
            if (expenditure[i] >= m * 2) notifications++;

            count[expenditure[i - d]]--;
            count[expenditure[i]]++;
        }

        return notifications;

    }
    static double FindMedian(int[] count, int i1, int i2)
    {
        var m1 = 0;
        var m2 = 0;
        for (int j = 0, k = 0; k <= i1; k += count[j], j++) m1 = j;
        for (int j = 0, k = 0; k <= i2; k += count[j], j++) m2 = j;

        return (m1 + m2) / 2d;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp))
        ;
        int result = activityNotifications(expenditure, d);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
