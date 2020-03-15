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

    // Complete the poisonousPlants function below.
    static int poisonousPlants(int[] p)
    {
        if (p.Length == 0)
            return 0;

        var left = int.MinValue;
        var head = new List<Stack>();
        for (var i = 0; i < p.Length; i++)
        {
            var plant = p[i];
            if (plant > left)
                head.Add(new Stack { Pos = i, Count = 0 });
            left = plant;
            head[head.Count - 1].Count++;
        }

        var day = 0;
        bool deadPlant;

        do
        {
            deadPlant = false;
            Stack prev = head[0];
            for (int i = 1; i < head.Count; i++)
            {
                var curr = head[i];
                if (curr.Count == 0)
                    continue;

                if (curr.Peek(p) > prev.PeekLast(p))
                {
                    deadPlant = true;
                    curr.Pop();
                }
                prev = curr;
            }

            if (deadPlant)
                day++;
        } while (deadPlant);

        return day;
    }

    class Stack
    {
        public int Pos { get; set; }
        public int Count { get; set; }

        public int Peek(int[] p) => p[Pos];

        public int PeekLast(int[] p) => p[Pos + Count - 1];

        public void Pop()
        {
            if (Count <= 0) return;
            Pos++;
            Count--;
        }
    }
    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] p = Array.ConvertAll(Console.ReadLine().Split(' '), pTemp => Convert.ToInt32(pTemp))
        ;
        int result = poisonousPlants(p);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
