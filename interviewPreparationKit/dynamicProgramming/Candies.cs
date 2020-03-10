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

    // Complete the candies function below.
    //optimum O(N)
    static long candies(int n, int[] arr) {
        Console.WriteLine(arr.ToString());
        long[] candies = new long[n];

        candies[0] = 1;
        //POPULATE RISES
        for (int i = 1; i < n; i++) {//walk through kids // DISTRIBUTE CANDIES TO RISES LEFT TO RIGHT
            if (arr[i] > arr[i - 1]) {//if the next child is ranked higher//RISE CHILD
                candies[i] = candies[i - 1] + 1; //no. of candies is 1 more than the no. of candies before it //I IS A VALLEY AND I+1 IS A PEAK
            } else {
                candies[i] = 1; //no. of candies returns to 1 //I IS A VALLEY I+1 IS A RISE
            }
        }
        //POPULATE FALLS
        for (int i = n - 2; i >= 0; i--) {//starting from second last kid walking backwards // DISTRIBUTE CANDIES TO FALLS RIGHT TO LEFT
            if (arr[i] > arr[i + 1]) {//if left kid's rating is higher //FALL CHILD //I IS A PEAK I + 1 IS A VALLEY
                candies[i] = Math.Max(candies[i], candies[i + 1] + 1);//candy count is now the higher of the 2 PEAK CHILD
            }
        }

        long sum = 0;
        for (int i = 0; i < n; i++) {//add up no. of candies needed
            sum += candies[i];
        }
        return sum;
    
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int [n];

        for (int i = 0; i < n; i++) {
            int arrItem = Convert.ToInt32(Console.ReadLine());
            arr[i] = arrItem;
        }

        long result = candies(n, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
