using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class sum
{
    static void Main()
    {

        // Task 5: Display sum of 10 numbers using an array
        int[] numbers = new int[10];
        int sum = 0;
        Console.WriteLine("Enter 10 numbers: ");
        for (int i = 0; i < 10; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
            sum += numbers[i];
        }
        Console.WriteLine($"The sum of the 10 numbers is: {sum}");

        // Task 6: Display sum of max 10 positive integers
        sum = 0;
        int count = 0;
        Console.WriteLine("Enter up to 10 positive integers (enter a negative number to stop): ");
        while (count < 10)
        {
            int num = int.Parse(Console.ReadLine());
            if (num < 0)
            {
                break;
            }
            sum += num;
            count++;
        }
        Console.WriteLine($"The sum of the entered positive integers is: {sum}");

        // Task 7: Take a name and split it into Array
        Console.WriteLine("Enter a name: ");
        string name = Console.ReadLine();
        char[] nameArray = name.ToCharArray();
        Console.WriteLine("The name split into an array: ");
        foreach (char c in nameArray)
        {
            Console.WriteLine(c);
        }

        // Task 8: Take a name and count number of vowels in it
        int vowelCount = 0;
        foreach (char c in name)
        {
            if ("AEIOUaeiou".IndexOf(c) >= 0)
            {
                vowelCount++;
            }
        }
        Console.WriteLine($"The number of vowels in the name is: {vowelCount}");
    }
}

