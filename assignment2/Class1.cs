using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Class1
    {
        public bool CompareStrings(string str1, string str2)
        {
            return str1 == str2;
        }

        public string CopyString(string source, string destination)
        {
            destination = source;
            return destination;
        }

        public string CombineStrings(string str1, string str2)
        {
            return str1 + str2;
        }

        public void ExecuteStringOperations()
        {
            Console.WriteLine("Enter the first string:");
            string str1 = Console.ReadLine();

            Console.WriteLine("Enter the second string:");
            string str2 = Console.ReadLine();

            Console.WriteLine($"Are the strings equal? {CompareStrings(str1, str2)}");

            string copiedString = CopyString(str1, str2);
            Console.WriteLine($"Copied string: {copiedString}");

            string combinedString = CombineStrings(str1, str2);
            Console.WriteLine($"Combined string: {combinedString}");
        }
    }
}

