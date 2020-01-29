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

    // Complete the isBalanced function below.
    static string isBalanced(string s) {
           const string no = "NO";
            const string yes = "YES";

            var stack = new Stack<char>();

            foreach (var c in s)
            {
                //(, ), {, }, [, or ].
                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(c);
                        break;

                    case ')':
                    case '}':
                    case ']':
                        if (stack.Count == 0)
                            return no;
                        var open = stack.Pop();
                        if (c != getClosing(open))
                            return no;
                        break;

                    default:
                        return no;
                }
            }

            return stack.Count == 0 ? yes : no;
        }

        private static char getClosing(char open)
        {
            switch (open)
            {

                case '(': return ')';
                case '{': return '}';
                case '[': return ']';
                default: return '\0';
            }
        }
    static bool topDoesntPair (char c, char top)
    {
        return (top + 1 == c || top + 2 == c);
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            string s = Console.ReadLine();

            string result = isBalanced(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
