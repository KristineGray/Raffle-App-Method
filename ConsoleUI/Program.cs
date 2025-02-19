﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            MultiLineAnimation();
            PrintGuestsName();
            PrintWinner();

            Console.ReadKey(); // For testing
        }

        //Start writing your code here

        //Variables:
        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random _rdm = new Random();

        //Methods:
        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string data = Console.ReadLine();
            return data;
        }

        private static void GetUserInfo()
        {
            string otherGuest = "yes";
            string name;
            do
            {
                name = GetUserInput("\nPlease enter your name ");
                while (string.IsNullOrWhiteSpace(name))
                {
                    name = GetUserInput("\nPlease enter your name ");
                }
                otherGuest = GetUserInput("\nDo you want to add another name?").ToLower();
                raffleNumber = GenerateRandomNumber(min, max);
                while (guests.ContainsKey(raffleNumber))
                    raffleNumber = GenerateRandomNumber(min, max);
                AddGuestsInRaffle(raffleNumber, name);
            }
            while (otherGuest == "yes" || otherGuest == "y");

        }

        private static int GenerateRandomNumber(int min, int max)
        {
            return _rdm.Next(min, max);
        }

        private static void AddGuestsInRaffle(int raffleNumber, string guest)
        {
            guests.Add(raffleNumber, guest);
        }

        private static void PrintGuestsName()
        {
            foreach (KeyValuePair<int, string> guest in guests)
            {
                Console.WriteLine($"{guest.Key}: {guest.Value}");
            }
        }

        private static int GetRaffleNumber(Dictionary<int, string> people)
        {
            List<int> numbers = new List<int>();
            foreach (KeyValuePair<int, string> person in people)
            {
                numbers.Add(person.Key);
            }
            int rdmIndex = _rdm.Next(0, numbers.Count);
            return numbers[rdmIndex];
        }

        private static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests);
            string winnerName = guests[winnerNumber];
            Console.WriteLine($"\n\nThe winner is: {winnerName} with the raffle #{winnerNumber}");
        }


        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
