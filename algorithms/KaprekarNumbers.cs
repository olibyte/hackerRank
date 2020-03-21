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

    // Complete the kaprekarNumbers function below. //p upper q lower
    static void kaprekarNumbers(int p, int q) {
        bool found = false;
        for(long i = p; i <= q; i++){
            string numSquared = (i * i).ToString();
            long lengthRight = i.ToString().Length;
            long rightStartIndex = numSquared.Length - lengthRight;
            long rightNumber = Convert.ToInt64(numSquared.Substring((int)rightStartIndex));
            long leftNumber;
            if(rightStartIndex == 0){
                leftNumber = 0;
            }
            else{
                leftNumber = Convert.ToInt64(numSquared.Substring(0, (int)rightStartIndex));
            }
            long result = leftNumber + rightNumber;
            if(result == i){
                Console.Write(i.ToString() + " ");
                found = true;
            }
        }
        if(!found){
            Console.Write("INVALID RANGE");
        }
        
    }

    static void Main(string[] args) {
        int p = Convert.ToInt32(Console.ReadLine());

        int q = Convert.ToInt32(Console.ReadLine());

        kaprekarNumbers(p, q);
    }
}
