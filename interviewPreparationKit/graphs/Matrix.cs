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

    static int[] parents;
    static bool[] containsCar;
    static int result = 0;
    static int find(int n)
    {
        if (parents[n] != n)
            parents[n] = find(parents[n]);
        return parents[n];
    }

    static void union(int a, int b, int weight)
    {
        var ar = find(a);
        var br = find(b);
        if (containsCar[ar] && containsCar[br])
            result += weight;
        if (!containsCar[ar] && !containsCar[br])
        {
            parents[br] = ar;
        }
        else
        {
            parents[br] = ar;
            containsCar[br] = true;
            containsCar[ar] = true;
        }
    }
    struct Road
    {
        public int source { get; set; }
        public int dest { get; set; }
        public int weight { get; set; }
    }
    // Complete the minTime function below.
    static int minTime(int[][] roads, int[] machines)
    {
        int n = roads.Length + 1;
        int k = machines.Length;
        parents = new int[n];
        containsCar = new bool[n];
        var cars = new HashSet<int>();
        for (int i = 0; i < k; i++)
        {
            cars.Add(machines[i]);
            containsCar[machines[i]] = true;
        }

        for (int i = 0; i < n; i++)
            parents[i] = i;
        var rds = new List<Road>();
        for (int i = 0; i < n - 1; i++)
            rds.Add(new Road { source = roads[i][0], dest = roads[i][1], weight = roads[i][2] });
        rds.Sort(new roadComparer());
        for (int i = 0; i < n - 1; i++)
        {
            union(rds[i].source, rds[i].dest, rds[i].weight);
        }
        return result;
    }

    class roadComparer : IComparer<Road>
    {
        public int Compare(Road x, Road y)
        {
            return y.weight - x.weight;
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[][] roads = new int[n - 1][];

        for (int i = 0; i < n - 1; i++)
        {
            roads[i] = Array.ConvertAll(Console.ReadLine().Split(' '), roadsTemp => Convert.ToInt32(roadsTemp));
        }

        int[] machines = new int[k];

        for (int i = 0; i < k; i++)
        {
            int machinesItem = Convert.ToInt32(Console.ReadLine());
            machines[i] = machinesItem;
        }

        int result = minTime(roads, machines);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
