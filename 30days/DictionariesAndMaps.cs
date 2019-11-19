using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        Dictionary<string, string> PhoneBook = new Dictionary<string, string>();

            int num = Convert.ToInt32(Console.ReadLine());

            // split the entries into 2 parts, assigning them to a string array
            for (int i = 0; i < num; i++)
            {
                string[] dictEntries = Console.ReadLine().Split(' ');
                // add the entries into the dict as a key value pair
                PhoneBook.Add(dictEntries[0], dictEntries[1]);
            }

            String name;

            while (( name = Console.ReadLine()) != null)
            {
                try
                {
                    Console.WriteLine($"{name}={PhoneBook[name]}");
                }
                catch
                {
                    Console.WriteLine("Not found");
                }
            }
    }
}

