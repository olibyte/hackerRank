using System;
using System.Collections.Generic;

namespace Vector
{


    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return Id + "[" + Name + "]";
        }

    }

    class Tester
    {

        private static bool CheckIntSequence<T>(T[] certificate, Vector<T> vector)
        {
            if (certificate.Length != vector.Count) return false;
            int counter = 0;
            foreach (T value in vector)
            {
                if (!value.Equals(certificate[counter])) return false;
                counter++;
            }
            return true;
        }

        static void Main(string[] args)
        {
            string result = "";

            Vector<int> vector = null;

            // test 1
            try
            {
                Console.WriteLine("\nTest A: Run a sequence of operations: ");
                Console.WriteLine("Create a new vector by calling 'Vector<int> vector = new Vector<int>(5);'");
                vector = new Vector<int>(5);
                Console.WriteLine(" :: SUCCESS");
                Console.WriteLine("Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9");
                vector.Add(2); vector.Add(6); vector.Add(8); vector.Add(5); vector.Add(5); vector.Add(1); vector.Add(8); vector.Add(5);
                vector.Add(3); vector.Add(5); vector.Add(7); vector.Add(1); vector.Add(4); vector.Add(9);
                Console.WriteLine(" :: SUCCESS");
                result = result + "A";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 2
            try
            {
                Console.WriteLine("\nTest B: Run a sequence of operations: ");
                Console.WriteLine("Check whether the interface IEnumerable<T> is implemented for the Vector<T> class");
                if (!(vector is IEnumerable<int>)) throw new Exception("Vector<T> does not implement IEnumerable<T>");
                Console.WriteLine(" :: SUCCESS");
                Console.WriteLine("Check whether GetEnumerator() method is implemented");
                vector.GetEnumerator();
                Console.WriteLine(" :: SUCCESS");
                result = result + "B";
            }
            catch (NotImplementedException)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine("GetEnumerator() method is not implemented");
                result = result + "-";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 3
            try
            {
                Console.WriteLine("\nTest C: Run a sequence of operations: ");
                Console.WriteLine("Return the Enumerator of the Vector<T> and check whether it implements IEnumerator<T>");
                if (!(vector.GetEnumerator() is IEnumerator<int>)) throw new Exception("The Enumerator of the Vector<T> does not implement IEnumerator<T>");
                Console.WriteLine("Check the initial value of Current of the Enumerator");
                if (vector.GetEnumerator().Current!= default(int)) throw new Exception("The initial Current value of the Enumerator is incorrect. Must be the value of "+ default(int));

                Console.WriteLine("Check the value of Current of the Enumerator after MoveNext() operation");
                IEnumerator<int> enumerator = vector.GetEnumerator();
                enumerator.MoveNext();
                if (enumerator.Current != 2) throw new Exception("The value of Current of the Enumerator after MoveNext() operation is incorrect. Must be the value of " + vector[0]);
                Console.WriteLine(" :: SUCCESS");
                result = result + "C";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 4
            try
            {
                Console.WriteLine("\nTest D: Check the content of the Vector<int> by traversing it via 'foreach' statement ");
                if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 }, vector)) throw new Exception("The 'foreach' statement produces an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "D";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 5
            int num = 14;
            Student[] certificate_student = new Student[num];
            Vector<Student> students = null;
            try
            {
                string[] names = new string[] { "Kelly", "Cindy", "John", "Andrew", "Richard", "Michael", "Guy", "Elicia", "Tom", "Iman", "Simon", "Vicky" };
                Random random = new Random(100);
                Console.WriteLine("\nTest E: Run a sequence of operations: ");
                Console.WriteLine("Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'");
                students = new Vector<Student>();
                for (int i = 0; i < num; i++)
                {
                    Student student = new Student() { Name = names[random.Next(0, names.Length)], Id = i };
                    Console.WriteLine("Add student with record: " + student.ToString());
                    students.Add(student);
                    certificate_student[i] = student;
                }
                Console.WriteLine("Print the vector of students via students.ToString();");
                Console.WriteLine(students.ToString());

                Console.WriteLine(" :: SUCCESS");
                result = result + "E";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 6
            try
            {
                Console.WriteLine("\nTest F: Check the content of the Vector<Student> by traversing it via 'foreach' statement ");
                if (!CheckIntSequence(certificate_student, students)) throw new Exception("The 'foreach' statement produces an incorrect sequence of dtudents");
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
