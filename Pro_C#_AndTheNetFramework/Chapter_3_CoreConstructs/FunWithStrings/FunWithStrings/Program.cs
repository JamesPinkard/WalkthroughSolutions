using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FunWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicStringFunctionality();

            StringConcatenation();

            EscapeChars();

            StringEquality();

            StringsAreImmutable();

            FunWithStringBuilder();

            StringSplitting();

            Console.ReadKey();
        }

        static void BasicStringFunctionality()
        {
            Console.WriteLine("=> Basic String Functionality:");
            string firstName = "Freddy";
            Console.WriteLine("Value of firstName: {0}", firstName);
            Console.WriteLine("firstName has {0} characters.", firstName.Length);
            Console.WriteLine("firstName in uppercase: {0}", firstName.ToUpper());
            Console.WriteLine("firstName in lowercase: {0}", firstName.ToLower());
            Console.WriteLine("firstName contains the letter y?: {0}", firstName.Contains("y"));
            Console.WriteLine("firstName after replace: {0}", firstName.Replace("dy",""));
            Console.WriteLine();
        }

        static void StringConcatenation()
        {
            Console.WriteLine("=> String Concatenation:");
            string s1 = "Programming the ";
            string s2 = "PsychoDrill (PTP)";
            string s3 = s1 + s2;
            Console.WriteLine(s3);
            Console.WriteLine();
        }

        static void EscapeChars()
        {
            Console.WriteLine("=> Escape characters:\a");
            string strWithTabs = "Model\tColor\tSpeed\tPet Name\a ";
            Console.WriteLine(strWithTabs);

            Console.WriteLine("Everyone loves \"Hello World\"\a ");
            Console.WriteLine("C:\\MyApp\\bin\\Debug\a ");
            
            // Adds a total of 4 blank lines (then beep again!).
            Console.WriteLine("All finished.\n\n\n\a ");

            // The following string is printed verbatim,
            // thus all escape characters are displayed.
            Console.WriteLine(@"C:\MyApp\bin\Debug");
            Console.WriteLine();

            // White space is preserved with verbatim strings.
            string myLongString = @"This is a very
                very
                    very
                        long string";
            Console.WriteLine(myLongString);
            Console.WriteLine();

            // You can directly insert a double quote into a literal string
            // by doubling the quotation marks
            Console.WriteLine(@"Cerebus said ""Darrr! Pret-ty sun-sets""");
            Console.WriteLine();
        }

        static void StringEquality()
        {
            Console.WriteLine("=> String equality:");
            string s1 = "Hello!";
            string s2 = "Yo!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();

            // Test these strings for equality.
            Console.WriteLine("s1 == s2: {0}", s1 == s2);
            Console.WriteLine("s1 == Hello!: {0}", s1 == "Hello!");
            Console.WriteLine("s1 == HELLO!: {0}", s1 == "HELLO!");
            Console.WriteLine("s1 == hello!: {0}", s1 == "hello!");
            Console.WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));
            Console.WriteLine("Yo.Equals(s2): {0}", "Yo!".Equals(s2));
            Console.WriteLine();
        }

        static void StringsAreImmutable()
        {
            // Set initial string value.
            string s1 = "This is my string.";
            Console.WriteLine("s1 = {0}", s1);

            // Uppercase s1?
            string upperString = s1.ToUpper();
            Console.WriteLine("upperString = {0}", upperString);

            // Nope! s1 is in the same format!
            Console.WriteLine("s1 = {0}", s1);
            
            Console.WriteLine();
        }

        static void FunWithStringBuilder()
        {
            Console.WriteLine("=> Using the StringBuilder:");
            StringBuilder sb = new StringBuilder("** Games **");
            Console.WriteLine("StringBuilder's initial max Capacity is {0}", sb.Capacity);

            // Make a StringBuilder with an initial size of 256
            sb = new StringBuilder("**** Fantastic Games ****", 256);
            Console.WriteLine("StringBuilder with max capacity set to {0}", sb.Capacity);
            Console.WriteLine();

            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Morrowwind");
            sb.AppendLine("Deus Ex " + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            Console.WriteLine();

            sb.Replace("2", "Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
            Console.WriteLine();            
        }

        static void StringSplitting()
        {
            // Split text
            string s1 = "These are the words in my text when split";
            string[] myStrings = s1.Split();
            
            Console.WriteLine(s1);
            Console.WriteLine();
            foreach (var str in myStrings)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

            // Split new line text
            string s2 = "These are the lines \nin my other text";
            string[] myLines = Regex.Split(s2, "\r\n|\r|\n");            
            foreach (var line in myLines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();

            // Split multi line text
            string s3 = @"There are multiple
                        lines
                        in this text";
            string[] multiLines = Regex.Split(s3, "\r\n|\r|\n");
            foreach (var line in multiLines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }
}
