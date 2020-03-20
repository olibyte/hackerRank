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

    // Complete the primality function below.
     /**
    *   Improved O( n^(1/2)) ) Algorithm
    *    Checks if n is divisible by 2 or any odd number from 3 to sqrt(n).
    *    The only way to improve on this is to check if n is divisible by KNOWN PRIMES from 2 to sqrt(n).
    *
    *   @param n An integer to be checked for primality.
    *   @return true if n is prime, false if n is not prime.
    **/
    public static bool isPrime(int n){
        // check lower boundaries on primality
        if( n == 2 ){ 
            return true;
        } // 1 is not prime, even numbers > 2 are not prime
        else if( n == 1 || (n & 1) == 0){
            return false;
        }

        // Check for primality using odd numbers from 3 to sqrt(n)
        for(int i = 3; i <= Math.Sqrt(n); i += 2){
            // n is not prime if it is evenly divisible by some 'i' in this range
            if( n % i == 0 ){ 
                return false;
            }
        }
        // n is prime
        return true;
    }
    static string primality(int n) {
        return isPrime(n) ? "Prime" : "Not prime";
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int p = Convert.ToInt32(Console.ReadLine());

        for (int pItr = 0; pItr < p; pItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            string result = primality(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
