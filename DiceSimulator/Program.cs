using System;
using System.Collections.Generic;

namespace DiceSimulator
{
    class Program
    {

        public static List<int> results = new List<int>();
        public static int rolls;
        public static int total;

        static void Main(string[] args)
        {
            bool active = true;
            int min = 1;
            int max = 5;

            Console.WriteLine("Lisa Nilsson " + DateTime.Parse("2019-05-20").ToShortDateString() + "\n");
            while (active == true)
            {
                rolls = 0;
                total = 0;

                var dice = 0;

                Console.Write("Hur många tärningar ska kastas: ");

                var input = Console.ReadLine();
                var valid = int.TryParse(input, out dice);

                while (valid == false)
                {
                    Console.WriteLine("\nVänligen ange ett nummer");
                    Console.Write("Hur många tärningar ska kastas: ");
                    valid = int.TryParse(Console.ReadLine(), out dice);

                    while ((dice < min || dice > max) && valid) // Makes sure the user can only input accepted values
                    {
                        Console.Write("\nSkriv in ett tal mellan 1 och 5: ");
                        valid = int.TryParse(Console.ReadLine(), out dice);
                    }
                }

                while (dice < min || dice > max)
                {
                    Console.Write("\nSkriv in ett tal mellan 1 och 5  "); // Same as above
                    valid = int.TryParse(Console.ReadLine(), out dice);
                }

                var rnd = new Random();
                for (int i = 0; i < dice; i++)
                {
                    rolls++;
                    Console.WriteLine("\nKast: " + rolls);
                    var value = rnd.Next(1, 7);

                    if (value == 6) 
                    {
                        Console.WriteLine("Värdet av kastet är 6, slå om 2 gånger\n");
                        Reroll(); // Calls the reroll method
                    }
                    else
                    {
                        results.Add(value);
                        total += value;

                        Console.WriteLine("Värdet av kastet är: " + value);
                        Console.WriteLine("Totalt värde av alla kast: " + total);
                    }
                }

                Console.WriteLine("\nTotala rullningar är: " + rolls);
                Console.WriteLine("Summan av alla rullningar är: " + total);

                Console.WriteLine("\nVill du köra igen ja/nej?");
                string response = Console.ReadLine().ToLower();

                List<string> responses = new List<string>() { "ja", "nej" };

                while (!responses.Contains(response))
                {
                    Console.WriteLine("Vänligen svara på frågan med ja/nej");
                    response = Console.ReadLine();
                }

                if (response == "ja")
                {
                    Console.WriteLine();
                    continue;

                }
                else if (response == "nej")
                {
                    active = false;

                }

            }
        }

        public static void Reroll()
        {
            for (int i = 1; i <= 2; i++) // Starts a new loop for two dice
            {
                rolls++;
                Console.WriteLine("Kast: " + rolls);
                var value = new Random().Next(1, 7);
                if (value != 6)
                {
                    results.Add(value);
                    total += value;
                    Console.WriteLine("värdet av kastet är: " + value);
                    Console.WriteLine("Totalt värde av alla kast: " + total + "\n");
                }
                else
                {
                    Console.WriteLine("slå två nya tärningar då resultatet är 6\n");
                    Reroll(); // Calls the same method which rolls 2 new dice as long as a result is a 6
                }

            }
        }
    }
}
