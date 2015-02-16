using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;

namespace StringIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Indexers ****\n");

            PersonCollection myPeople = new PersonCollection();

            myPeople["Homer"] = new Person("Homer", "Simpson", 40);
            myPeople["Marge"] = new Person("Marge", "Simpson", 38);

            // Get "Homer" and print data.
            Person homer = myPeople["Homer"];
            Console.WriteLine(homer.ToString());
            
            Console.WriteLine();
            MultiIndexerWithDataTable();

            Console.ReadLine();
        }

        static void MultiIndexerWithDataTable()
        {
            // Make a simple DataTable with 3 columns.

            DataTable myTable = new DataTable();

            myTable.Columns.Add(new DataColumn("FirstName"));
            myTable.Columns.Add(new DataColumn("LastName"));
            myTable.Columns.Add(new DataColumn("Age"));

            // Now add a row to the table
            myTable.Rows.Add("Mel", "Appleby", 60);

            // Use multidimension indexer to get details of first row.
            Console.WriteLine("First Name: {0}", myTable.Rows[0][0]);
            Console.WriteLine("Last Name: {0}", myTable.Rows[0][1]);
            Console.WriteLine("Age : {0}", myTable.Rows[0][2]);
        }
    }

}
