using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int x;
        x = Convert.ToInt32(Console.ReadLine());
        //x is the number of test cases.
        for (int i = 0; i < x; i++)
        {
            string s;
            string s1 = "";
            string s2 = "";
            s = Console.ReadLine();

            for (int j = 0; j < s.Length; j++)
            {
                //if index is even
                if (j % 2 == 0)
                {
                    //new string with char from even indexed
                    s1 += s[j];
                }
                //else it is odd
                else
                {
                    //new string with char from odd indexed
                    s2 += s[j];
                }
            }
            //concatenate for new string
            Console.WriteLine(s1 + " " + s2);
        }
    }
}

