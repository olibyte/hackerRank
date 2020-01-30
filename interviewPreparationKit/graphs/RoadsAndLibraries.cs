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

     private static long roadsAndLibraries(int n , int c_lib , int c_road , int[][] cities)
    {
        Func<int , long> costToBuildComponent = c_lib > c_road ? (numLibraries => c_lib + c_road * (numLibraries - 1)) : (Func<int , long>)(numLibraries => c_lib * numLibraries);

        long cost = 0;
        var marked = new bool[n];
        //Debugger.Launch();
        List<int>[] graph = BuildGraph(cities , n);
        for (var i = 0 ; i < n ; i++)
            if (!marked[i])
                cost += costToBuildComponent(dfs(i , graph , marked));

        return cost;
    }

    private static int dfs(int i , List<int>[] graph , bool[] marked)
    {
        var numMarked = 1;
        marked[i] = true;
        foreach (var adj in adjacents(i , graph).Where(a => !marked[a]))
            numMarked += dfs(adj , graph , marked);
        return numMarked;
    }

    private static IEnumerable<int> adjacents(int i , List<int>[] graph)
    {
        foreach (var item in graph[i])
            yield return item;
    }

    private static List<int>[] BuildGraph(int[][] cities , int n)
    {
        var graph = new List<int>[n];

        for (var i = 0 ; i < n ; i++)
            graph[i] = new List<int>();

        for (var i = 0 ; i < cities.Length ; i++)
        {
            int a = cities[i][0] - 1, b = cities[i][1] - 1;
            graph[a].Add(b);
            graph[b].Add(a);
        }

        return graph;
    }


    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string[] nmC_libC_road = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nmC_libC_road[0]);

            int m = Convert.ToInt32(nmC_libC_road[1]);

            int c_lib = Convert.ToInt32(nmC_libC_road[2]);

            int c_road = Convert.ToInt32(nmC_libC_road[3]);

            int[][] cities = new int[m][];

            for (int i = 0; i < m; i++) {
                cities[i] = Array.ConvertAll(Console.ReadLine().Split(' '), citiesTemp => Convert.ToInt32(citiesTemp));
            }

            long result = roadsAndLibraries(n, c_lib, c_road, cities);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
