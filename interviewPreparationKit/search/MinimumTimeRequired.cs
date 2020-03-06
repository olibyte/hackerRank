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

    //You are planning production for an order. You have a number of machines that each have a fixed number of days to produce an item. 
    //Given that all the machines operate simultaneously, determine the minimum number of days to produce the required order.
    // Complete the minTime function below.
    static long minTime(long[] machines, long goal)
    {

        long minDays = (goal * machines.Min()) / machines.Length;
        long maxDays = (goal * machines.Max()) / machines.Length;

        while (minDays < maxDays) //low < high  
        {
            //traverse array and sum total items produced by each machine.
            long days = (minDays + maxDays) / 2; //mid for binary search
            
            var result = (from m in machines
                          select days / m).Sum(); //LINQ for Binary Search.

            if (result >= goal)
            {
                maxDays = days;
            }
            else
            {
                minDays = days + 1;
            }
        }

        return minDays;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nGoal = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nGoal[0]);

        long goal = Convert.ToInt64(nGoal[1]);

        long[] machines = Array.ConvertAll(Console.ReadLine().Split(' '), machinesTemp => Convert.ToInt64(machinesTemp))
        ;
        long ans = minTime(machines, goal);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
