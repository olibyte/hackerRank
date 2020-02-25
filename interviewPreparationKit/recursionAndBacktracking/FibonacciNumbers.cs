using System;
using System.Collections.Generic;
using System.IO;

class Solution
{

    public static int Fibonacci(int n)
    {
        return n <= 1 ? n : Fibonacci(n - 1) + Fibonacci(n - 2);
    }
    public static void Fibonacci_Iterative(int len)
    {
        int a = 0, b = 1, c = 0;
        Console.Write("{0} {1}", a, b);
        for (int i = 2; i < len; i++)
        {
            c = a + b;
            Console.Write(" {0}", c);
            a = b;
            b = c;
        }
    }
    public static void Fibonacci_Recursive(int len)
    {
        Fibonacci_Rec_Temp(0, 1, 1, len);
    }
    private static void Fibonacci_Rec_Temp(int a, int b, int counter, int len)
    {
        if (counter <= len)
        {
            Console.Write("{0} ", a);
            Fibonacci_Rec_Temp(b, a + b, counter + 1, len);
        }
    }
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Fibonacci(n));
    }
}