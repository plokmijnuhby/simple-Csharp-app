using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GuessNumber();
        }
        static int LongestSequence(string sales)
        {
            int longest = 0;
            int current = 0;
            foreach (string s in sales.Split(','))
            {
                if (s == "0")
                {
                    current++;
                }

                if (current > longest)
                {
                    longest = current;
                }
                
                if (s != "0")
                {
                    current = 0;
                }
            }
            return longest;
        }
        static IEnumerable<string> Anagrams(string words)
        {
            foreach (string word in words.Split(','))
            {
                var letters = new bool[] { false, false, false, false };
                bool correct = true;
                foreach (char letter in word)
                {
                    int index = "star".IndexOf(letter);
                    if (index == -1 || letters[index])
                    {
                        correct = false;
                        break;
                    }
                    letters[index] = true;
                }
                if (correct && !letters.Contains(false))
                {
                    yield return word;
                }
            }
        }
        static void Stars()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(new string(' ', 4 - i));
                Console.WriteLine(new string('*', 2 * i + 1));
            }
        }
        static void StarDiamond()
        {
            Stars();
            for (int i = 3; i >= 0; i--)
            {
                Console.Write(new string(' ', 4 - i));
                Console.WriteLine(new string('*', 2 * i + 1));
            }
        }
        static string Reverse(string input)
        {
            return (string)input.Reverse();
        }
        static bool Palindrome(string input)
        {
            string normalised = input.Replace(" ", "");
            return normalised == (string)normalised.Reverse();
        }
        static int DigitalRoot(int input)
        {
            return input.ToString().Sum(c => int.Parse(c.ToString()));
        }
        static Tuple<int,int> TwoSums(List<int> list, int target)
        {
            int[] indices = {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
            for (int i = 0; i < list.Count; i++)
            {
                int el = list[i];
                if (indices[10-el] != -1)
                {
                    return new Tuple<int,int>(indices[10-el], i);
                }
                if (indices[el] == -1)
                {
                    indices[el] = i;
                }
            }
            return null;
        }
        static int NthPrime(int n)
        {
            var primes = new List<int>();
            int i = 2;
            while (primes.Count < n)
            {
                if (!primes.Any(prime => i % prime == 0))
                {
                    primes.Add(i);
                }
                i++;
            }
            return primes[primes.Count - 1];
        }

        static int PrimeAfterN(int n)
        {
            var primes = new List<int>();
            int i = 2;
            int last = 0;
            while (last < n)
            {
                if (!primes.Any(prime => i % prime == 0))
                {
                    primes.Add(i);
                }
                i++;
            }
            return last;
        }

        static void GuessNumber()
        {
            int num = new Random().Next(100);
            Console.WriteLine("Guess the number between 1 and 99 in 5 tries.");
            for (int i = 0; i < 5; i++)
            {
                int guess;
                while (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("That's not a number! Don't be silly!");
                };
                if (guess == num)
                {
                    Console.WriteLine("Correct!");
                    Console.Read();
                    return;
                }
                else if (guess < num)
                {
                    Console.WriteLine("Too low!");
                }
                else if (guess > num)
                {
                    Console.WriteLine("Too high!");
                }
            }
            Console.WriteLine("You didn't get it!");
            Console.WriteLine($"The answer was {num}.");
            Console.Read();
        }
    }
}
