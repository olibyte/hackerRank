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

static void Execute()
    {
        int q = Convert.ToInt32(Console.ReadLine());

        int[][] queries = new int[q][];

        for (int i = 0; i < q; i++)
        {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        int[] ans = maxCircle(queries);

        Console.WriteLine(string.Join("\n", ans));
    }
    // Complete the maxCircle function below.
    static int[] maxCircle(int[][] queries) {
Dictionary<int, int> d = new Dictionary<int, int>();
        Dictionary<int, HashSet<int>> friends = new Dictionary<int, HashSet<int>>();

        int id = 0;
        int maxCircle = 2;
        List<int> result = new List<int>();

        foreach (var q in queries)
        {
            var con0 = d.ContainsKey(q[0]);
            var con1 = d.ContainsKey(q[1]);

            if (con0 || con1)
            {
                int val1 = con0 ? d[q[0]] : 0;
                int val2 = con1 ? d[q[1]] : 0;
                int max = Math.Max(val1, val2);
                int min = Math.Min(val1, val2);
                var set = friends[max];

                if (min == 0)
                {
                    if (con1)
                    {
                        d.Add(q[0], max);
                        set.Add(q[0]);
                    }
                    else
                    {
                        d.Add(q[1], max);
                        set.Add(q[1]);
                    }
                }
                else if (max != min)
                {
                    set.UnionWith(friends[min]);

                    foreach (int i in friends[min])
                        d[i] = max;

                    friends.Remove(min);
                }

                if (set.Count > maxCircle)
                    maxCircle = set.Count;
            }
            else
            {
                id++;
                d.Add(q[0], id);
                d.Add(q[1], id);
                friends.Add(id, new HashSet<int> { q[0], q[1] });
            }

            result.Add(maxCircle);
        }

        return result.ToArray();

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        int[][] queries = new int[q][];

        for (int i = 0; i < q; i++) {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        int[] ans = maxCircle(queries);

        textWriter.WriteLine(string.Join("\n", ans));

        textWriter.Flush();
        textWriter.Close();
    }
}
