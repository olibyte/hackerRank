using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Start_LINQ_XML
{
    class Start_LINQ_XML
    {

        static void Main(string[] args)
        {
            var custQuery = 
                from c in XDocument.Load("Customers.XML").Descendants(Customer)
                where (c.Element("State").Value) == "OR"
                select (c.Element("First").Value);

            foreach(var c in custQuery)
            {
                Console.WriteLine("{0", c);
            }
            

            Console.ReadKey();
            
        }
    }
}
