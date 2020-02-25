/*
Function Description

Complete the getMinimumCost function in the editor below. It should return the minimum cost to purchase all of the flowers.

getMinimumCost has the following parameter(s):
c: an array of integers representing the original price of each flower
k: an integer, the number of friends

Input Format
The first line contains two space-separated integers  and , the number of flowers and the number of friends.
The second line contains  space-separated positive integers , the original price of each flower.

Output Format

Print the minimum cost to buy all  flowers.
*/

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

    // Complete the getMinimumCost function below.
    static int getMinimumCost(int k, int[] c)
    {
        int i = c.Length - 1;
        int mul = 1;
        int ans = 0;
        Array.Sort(c);
        while (i >= 0)
        {
            for (int j = 0; j < k && i >= 0; j++)
            {
                ans += c[i] * mul;
                i--;
            }
            mul++;
        }
        return ans;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int minimumCost = getMinimumCost(k, c);

        textWriter.WriteLine(minimumCost);

        textWriter.Flush();
        textWriter.Close();
    }
}