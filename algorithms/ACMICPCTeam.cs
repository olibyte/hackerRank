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

    // Complete the acmTeam function below.
    static int[] acmTeam(string[] topic)
    {
        int numOfAttendees = topic.Length;
        int numOfTopics = (topic[0]).Length;

        int maxSubjects = 0;
        int maxMatchingTeams = 0;
        for (int i = 0; i < numOfAttendees - 1; i++)
        {
            for (int j = i + 1; j < numOfAttendees; j++)
            {
                int knownSubjectCount = 0;
                String attendee1 = topic[i];
                String attendee2 = topic[j];
                for (int k = 0; k < numOfTopics; k++)
                {
                    char t1 = attendee1[k];
                    char t2 = attendee2[k];
                    if (t1 == '1' || t2 == '1')
                    {
                        knownSubjectCount++;
                    }
                }
                if (maxSubjects < knownSubjectCount)
                {
                    maxSubjects = knownSubjectCount;
                    maxMatchingTeams = 1;
                }
                else if (maxSubjects == knownSubjectCount)
                {
                    maxMatchingTeams++;
                }
            }
        }

        int[] result = new int[] { maxSubjects, maxMatchingTeams };

        return result;


    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        string[] topic = new string[n];

        for (int i = 0; i < n; i++)
        {
            string topicItem = Console.ReadLine();
            topic[i] = topicItem;
        }

        int[] result = acmTeam(topic);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
