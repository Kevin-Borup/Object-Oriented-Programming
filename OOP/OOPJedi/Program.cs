using System;
using System.Linq;
using System.Collections.Generic;

namespace OOPJedi
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = new Dictionary<string, int>();

            people.Add("Kevin", 21);
            people["Mikkel"] = 99;

            Console.WriteLine($"{people.ElementAt(0).Key} - {people.ElementAt(0).Value}");

            Dictionary<string, bool> characters = new Dictionary<string, bool>() 
            { 
                { "Luke", true }, 
                { "Han", false }, 
                { "Chewbacca", false } 
            };

            characters.Remove("Han");

            foreach (var existance in characters)
            {
                Console.WriteLine($"Name: {existance.Key}");
            }

        }
    }
}
