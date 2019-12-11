using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    public static bool isPrime(int n)
    {
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var T = int.Parse(Console.ReadLine());

        for (int i = 0; i < T; i++)
        {
            int n = int.Parse(Console.ReadLine());

            if (n >= 2 && isPrime(n))
            {
                Console.WriteLine("Prime");
            }
            else
            {
                Console.WriteLine("Not prime");
            }
        }
    }
}