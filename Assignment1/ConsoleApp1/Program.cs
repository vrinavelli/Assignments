// See https://aka.ms/new-console-template for more information
using System;

class program
{
    static void Main()
    {
        //for (int i = 2; i < 101; i++)
        //{
        //    Console.WriteLine(i);
        //}
        for (int i = 1; i < 10; i++)
        {
            Console.WriteLine($"5 * {i} = {5 * i}");
        }

        Console.WriteLine("Enter a character: ");
        char c = Console.ReadKey().KeyChar;
        Console.WriteLine();

        if (char.IsDigit(c))
        {
            Console.WriteLine($"{c} is an integer.");
        }
        else if (char.IsLetter(c))
        {
            if ("AEIOUaeiou".IndexOf(c) >= 0)
            {
                Console.WriteLine($"{c} is a vowel.");
            }
            else
            {
                Console.WriteLine($"{c} is a consonant.");
            }
        }
    }
}
