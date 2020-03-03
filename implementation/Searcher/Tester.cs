using System;
using System.Collections.Generic;

namespace Vector
{

    public class AscendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A - B;
        }
    }

    public class DescendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return B - A;
        }
    }

    public class OddNumberFirstComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A % 2 - B % 2;
        }
    }

    class Tester
    {
        private static bool CheckAscending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] > vector[i + 1]) return false;
            return true;
        }

        private static bool CheckDescending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] < vector[i + 1]) return false;
            return true;
        }

        private static bool CheckOddNumberFirst(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] % 2 > vector[i + 1] % 2) return false;
            return true;
        }

        static void Main(string[] args)
        {
            string result = "";
            int problem_size = 20;
            int[] data = new int[problem_size]; data[0] = 333;
            Random k = new Random(1000);
            for (int i = 1; i < problem_size; i++) data[i] = 100 + k.Next(900);

            Vector<int> vector = new Vector<int>(problem_size);

            // ------------------ BinarySearch ----------------------------------
            int[] temp = null; int check;

            try
            {
                vector.Sorter = null;
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new AscendingIntComparer());
                Console.WriteLine("\nTest A: Apply BinarySearch searching for number 333 to array of integer numbers sorted in AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                vector.Sort(new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                check = Array.BinarySearch(temp, 333, new AscendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(333, new AscendingIntComparer()) != check) throw new Exception("The resulting index (or return value) is incorrect.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "A";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                vector.Sorter = null;
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new AscendingIntComparer());
                Console.WriteLine("\nTest B: Apply BinarySearch searching for number " + (temp[0] - 1) + " to array of integer numbers sorted in AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                vector.Sort(new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                check = Array.BinarySearch(temp, temp[0] - 1, new AscendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(data[0] - 1, new AscendingIntComparer()) != check) throw new Exception("The resulting index (or return value) is incorrect.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "B";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                vector.Sorter = null;

                Console.WriteLine("\nTest C: Apply BinarySearch searching for number " + (temp[problem_size - 1] + 1) + " to array of integer numbers sorted in AscendingIntComparer: ");
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new AscendingIntComparer());
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                vector.Sort(new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                check = Array.BinarySearch(temp, temp[problem_size - 1] + 1, new AscendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(data[problem_size - 1] + 1, new AscendingIntComparer()) != check) throw new Exception("The resulting index (or return value) is incorrect.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "C";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                vector.Sorter = null;
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new DescendingIntComparer());
                Console.WriteLine("\nTest D: Apply BinarySearch searching for number 333 to array of integer numbers sorted in DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                vector.Sort(new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                check = Array.BinarySearch(temp, 333, new DescendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(333, new DescendingIntComparer()) != check) throw new Exception("The resulting index (or return value) is incorrect.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "D";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                vector.Sorter = null;
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new DescendingIntComparer());
                Console.WriteLine("\nTest E: Apply BinarySearch searching for number " + (temp[0] - 1) + " to array of integer numbers sorted in DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                vector.Sort(new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                check = Array.BinarySearch(temp, temp[0] - 1, new DescendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(data[0] - 1, new DescendingIntComparer()) != check) throw new Exception("The resulting index (or return value) is incorrect.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "E";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                vector.Sorter = null;

                Console.WriteLine("\nTest F: Apply BinarySearch searching for number " + (temp[problem_size - 1] + 1) + " to array of integer numbers sorted in DescendingIntComparer: ");
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new DescendingIntComparer());
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                vector.Sort(new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                check = Array.BinarySearch(temp, temp[problem_size - 1] + 1, new DescendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(data[problem_size - 1] + 1, new DescendingIntComparer()) != check) throw new Exception("The resulting index (or return value) is incorrect.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "F";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();
        }
    }
}
