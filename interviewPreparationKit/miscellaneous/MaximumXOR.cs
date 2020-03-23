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

    // Complete the maxXor function below. TO DO: Optimise the solution to execute within the time limits.
    static int[] maxXor(int[] arr, int[] queries) {
        // solve here
        int[] maxXor= new int [queries.Length];
        Array.Sort(arr);
       
        for(int i=0; i<queries.Length; i++){
            int max = 0;
           for(int j=0; j<arr.Length; j++){
               int xor = (queries[i]^arr[j]); 
               if(xor>max){
                 max=xor;
               }  
           }
           maxXor[i]=max;
        }
        return maxXor;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int m = Convert.ToInt32(Console.ReadLine());

        int[] queries = new int [m];

        for (int i = 0; i < m; i++) {
            int queriesItem = Convert.ToInt32(Console.ReadLine());
            queries[i] = queriesItem;
        }

        int[] result = maxXor(arr, queries);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
