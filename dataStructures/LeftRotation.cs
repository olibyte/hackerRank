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



    static void Main(string[] args)
    {
        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;
            int leftRotationsIndex = 0;
            int arraylength = a.Length;

            int righRotationsNo = arraylength - d;
            //if (d <= righRotationsNo)
            //{
            //    while (leftRotationsIndex < d)
            //    {
            //        int temp = a[0];
            //        for (int i = 1; i < arraylength; i++)
            //        {
            //            a[i - 1] = a[i];
            //        }
            //        //int temp = a[n - 1];
            //        a[n - 1] = temp;
            //        leftRotationsIndex++;
            //    }
            //}
            //else
            //{
            //    int rightRotatioinIndex = 0;
            //    while (rightRotatioinIndex < righRotationsNo)
            //    {
            //        int temp = a[arraylength - 1];
            //        for (int i = arraylength - 1; i > 0; i--)
            //        {
            //            a[i] = a[i - 1];
            //        }
            //        a[0] = temp;
            //        rightRotatioinIndex++;
            //    }
            //}

            for (int i = 0; i < n; i++)
            {
                Console.Write(a[(i + d) % n] + " ");

            }
    }
}
