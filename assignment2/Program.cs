using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();

        Console.WriteLine($"Number of characters: {CountNoOfChars(sentence)}");
        Console.WriteLine($"Number of words: {CountNoOfWords(sentence)}");
        Console.WriteLine($"Reversed sentence: {ReverseSentence(sentence)}");
        Console.WriteLine($"Is palindrome: {IsPalindrome(sentence)}");
        var counts = CountVowelsConsonantsIntegersSpecialChars(sentence);
        Console.WriteLine($"Number of vowels: {counts.vowels}");
        Console.WriteLine($"Number of consonants: {counts.consonants}");
        Console.WriteLine($"Number of integers: {counts.integers}");
        Console.WriteLine($"Number of special characters: {counts.specialChars}");
    }

    static int CountNoOfChars(string temp)
    {
        return temp.Length;
    }

    static int CountNoOfWords(string temp)
    {
        return temp.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    static string ReverseSentence(string temp)
    {
        char[] charArray = temp.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static bool IsPalindrome(string temp)
    {
        string cleaned = new string(temp.Where(char.IsLetterOrDigit).ToArray()).ToLower();
        string reversed = new string(cleaned.Reverse().ToArray());
        return cleaned == reversed;
    }

    static (int vowels, int consonants, int integers, int specialChars) CountVowelsConsonantsIntegersSpecialChars(string temp)
    {
        int vowels = 0, consonants = 0, integers = 0, specialChars = 0;
        foreach (char c in temp)
        {
            if ("aeiouAEIOU".IndexOf(c) >= 0)
            {
                vowels++;
            }
            else if (char.IsLetter(c))
            {
                consonants++;
            }
            else if (char.IsDigit(c))
            {
                integers++;
            }
            else if (!char.IsWhiteSpace(c))
            {
                specialChars++;
            }
        }
        return (vowels, consonants, integers, specialChars);
    }
}
