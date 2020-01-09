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
    
    // Complete the countingValleys function below.
    //my submission
    // static int countingValleys(int n, string s) {
    //     int mountains = 0;
    //     int valleys = 0;
    //     int currentSeaLevel = 0;
    //     int previousSeaLevel = 0;

    //     for(int i = 0; i <n; i++)
    //     {
    //         switch(s[i])
    //         {
    //             case 'U':
    //                 currentSeaLevel++;
    //                 break;
    //             case 'D':
    //                 currentSeaLevel--;
    //                 break;
    //         }
    //         //if previously perfectly level and now below sea level
    //         if(previousSeaLevel == 0 && currentSeaLevel < 0)
    //         {
    //             valleys++;
    //         }
    //         previousSeaLevel = currentSeaLevel;
    //     }
    //     return valleys;
    // }
    static int countingValleys(int n, string s) {
        int altitude = 0;
        int mountains = 0;
        int valleys = 0;
        char[] hike = s.ToCharArray();

        foreach(char h in hike)
        {
            if(h == 'U')
            {
                if(altitude == -1)
                {
                    valleys++;
                }
                altitude++;
            }
            else 
            {
                altitude--;
            }
        }
        return valleys;
    }


    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        int result = countingValleys(n, s);

        textWriter.WriteLine(result);
 
        textWriter.Flush();
        textWriter.Close();
    }
}
