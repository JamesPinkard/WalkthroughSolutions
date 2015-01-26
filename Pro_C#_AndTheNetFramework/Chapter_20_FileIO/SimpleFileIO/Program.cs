using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleFileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple I/O with the File Type *****\n");
            
            /*
            // FileInfo.OpenRead and FileInfo.OpenWrite
            // Get a FileStream object with read-only permissions.
            FileInfo f3 = new FileInfo(@"C:\Code\Test3.dat");
            using (FileStream readOnlyStream = f3.OpenRead())
            {
                // Use the FileStream object...
            }

            // FileStream with write-only permissions
            FileInfo f4 = new FileInfo(@"C:\Code\Test4.dat");
            using (FileStream writeOnlyStream = f4.OpenWrite())
            {
                // Use the Filestream object...
            }

            // Get a StreamReader object.
            FileInfo f5 = new FileInfo(@"C:\boot.ini");
            using (StreamReader sReader = f5.OpenText())
            {
                // Use the StreamReader object
            }

            // Use Stream to Create Text
            FileInfo f6 = new FileInfo(@"C:\Code\Test6.txt");
            using (StreamWriter sWriter = f6.CreateText())
            {
                // Use the StreamWriter object
            }

            FileInfo f7 = new FileInfo(@"C:\Code\Test7.txt");
            using (StreamWriter sWriterAppend = f7.AppendText())
            {
                // Use the StreamWriter object...
            }
             */
            
            // Working with File Class
            string[] myTasks = {
                                   "Fix bathroom sink",
                                   "Call Dave",
                                   "Call Mom and Dad",
                                   "Play Xbox 360"
                               };

            // Write out all data to file on C drive.
            File.WriteAllLines(@"C:\Code\tasks.txt", myTasks);

            // Read it all back and print out.
            foreach (string task in File.ReadAllLines(@"C:\Code\tasks.txt"))
            {
                Console.WriteLine("TODO: {0}", task);
            }

            Console.ReadKey();
        }
    }
}
