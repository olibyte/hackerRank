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
    static Dictionary<int, int> numFreq = new Dictionary<int, int>();
    static Dictionary<int, int> freqNum = new Dictionary<int, int>();

    static List<int> freqQuery(List<List<int>> queries)
    {
        var result = new List<int>();
        foreach (List<int> query in queries)
        {
            int operation = query[0];
            int data = query[1];
            switch (operation)
            {
                case 1:
                    Insert(data);
                    break;
                case 2:
                    Delete(data);
                    break;
                case 3:
                    result.Add(Check(data));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        return result;
    }
    private static int Check(int data)
    {
        return freqNum.ContainsKey(data) && freqNum[data] > 0 ? 1 : 0;
    }
    private static void Delete(int data)
    {
        if (numFreq.ContainsKey(data))
        {
            int originalFreq = numFreq[data];
            numFreq[data] -= 1;
            if (numFreq[data] == 0)
            {
                numFreq.Remove(data);
            }
            else
            {
                UpdateFreqency(numFreq[data], 1);
            }
            UpdateFreqency(originalFreq, -1);
        }
    }
    private static void Insert(int data)
    {
        if (numFreq.ContainsKey(data))
        {
            int originalFreq = numFreq[data];
            numFreq[data] += 1;
            UpdateFreqency(numFreq[data], 1);
            UpdateFreqency(originalFreq, -1);
        }
        else
        {
            numFreq[data] = 1;
            UpdateFreqency(1, 1);
        }
    }
    private static void UpdateFreqency(int freq, int incr)
    {
        if (freqNum.ContainsKey(freq))
        {
            int newFreq = freqNum[freq] + incr;
            if (newFreq < 0)
            {
                throw new ApplicationException();
            }
            else if (newFreq == 0)
            {
                freqNum.Remove(freq);
            }
            else
            {
                freqNum[freq] = newFreq;
            }
        }
        else
        {
            if (incr < 1)
            {
                throw new ApplicationException();
            }
            freqNum[freq] = incr;
        }
    }
    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> ans = freqQuery(queries);

        textWriter.WriteLine(String.Join("\n", ans));

        textWriter.Flush();
        textWriter.Close();
    }
}