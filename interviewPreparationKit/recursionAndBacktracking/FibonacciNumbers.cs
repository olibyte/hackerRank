using System;
using System.Collections.Generic;
using System.IO;

class Solution
{

    public static int Fibonacci(int n)
    {
        return n <= 1 ? n : Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Fibonacci(n));
    }
}

