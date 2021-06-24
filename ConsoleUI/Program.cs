using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {


        //private static readonly 
        static Dictionary<int, string> guests = new Dictionary<int, string>(); //keep an eye on this readonly...
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random rdm = new Random();

        
        //Method to receive user input w/o doing console.write/readline
        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string response = Console.ReadLine();
            return response;
        }
        //Method to generate a random number for the raffle
        private static int GenerateRandomNumber(int min, int max)
        {
            int newNum = rdm.Next(min, max);
            return newNum;
        }
        //Method to add in guest name + their raffle number into our guests dictionary
        private static void AddGuestsInRaffle(int raffleNumber, string guest)
        {
            guests.Add(raffleNumber, guest);
        }

        //Loop to print names in Dictionary
        private static void PrintGuestsName()
        {
            foreach (var personName in guests)
            {
                Console.WriteLine(personName);
            }
        }

        //Get winning raffle number
        private static int GetRaffleNumber(Dictionary<int, string> guests)
        {
            int index;
            int winner;
            KeyValuePair<int, string> pair;
            for (int i = 0; i < 10; i++) //could be ++i
            {
                index = rdm.Next(guests.Count);
                pair = guests.ElementAt(index);
                winner = pair.Key;
                return winner;
            }
            return 1;
        }
        
        //Print Winner number & name
        private static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests);
            string winnerName = guests[winnerNumber];
            Console.WriteLine($"The Winner is: {winnerName} with the #{winnerNumber}");
        }



        //Method to return nothing 
        private static void GetUserInfo()
        {
            string otherGuest;
            string response1;
            int randomRaffleNumber;
            do //do the following: 
            {
                otherGuest = GetUserInput("Please enter a name: ").ToLower(); //print out quoted statement, then return that in a string called otherGuest
                randomRaffleNumber = GenerateRandomNumber(min, max);
                AddGuestsInRaffle(randomRaffleNumber, otherGuest);
                Console.WriteLine($"The name '{otherGuest}' has been succesfully recorded and their raffle number is {randomRaffleNumber}."); 
                Console.WriteLine("Would you like to enter another name? Enter 'yes' or 'no': "); 
                response1 = Console.ReadLine();
            } while (response1 == "yes" || response1 == ""); //continue looping "otherGuest" etc. while the response to "would you like to enter another name" is equal to "yes" or empty
        }









        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            PrintGuestsName();
            PrintWinner();
        }

        //Start writing your code here

        /*
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
        */
    }
}
