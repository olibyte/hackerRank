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

    // Complete the climbingLeaderboard function below.
    static int[] climbingLeaderboard(int[] scores, int[] alice)
    {
        var ranking = new int[scores.Length];
        var aliceFinal = new int[alice.Length];
        int score = 1;
        ranking[0] = 1;
        for (int i = 1; i < scores.Length; i++)
        {
            if (scores[i] < scores[i - 1])
                score++;
            ranking[i] = score;
        }
        int rememberLastPosition = scores.Length - 1;
        for (int i = 0; i < alice.Length; i++)
        {
            if (alice[i] > scores[0])
                aliceFinal[i] = 1;
            for (int j = rememberLastPosition; j >= 0; j--)
            {
                if (alice[i] == scores[j])
                {
                    aliceFinal[i] = ranking[j];
                    rememberLastPosition = j;
                    break;
                }
                else if (alice[i] < scores[j])
                {
                    aliceFinal[i] = ranking[j] + 1;
                    rememberLastPosition = j;
                    break;
                }
            }
        }
        return aliceFinal;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int scoresCount = Convert.ToInt32(Console.ReadLine());

        int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp))
        ;
        int aliceCount = Convert.ToInt32(Console.ReadLine());

        int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp))
        ;
        int[] result = climbingLeaderboard(scores, alice);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
