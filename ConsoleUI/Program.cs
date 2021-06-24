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

        
        //Method to receive user input w/o doing console.write/readline. This takes their input, stores it in a string, and returns that string
        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string response = Console.ReadLine();
            return response;
        }
        //Method to generate a random number for the raffle
        private static int GenerateRandomNumber(int min, int max) //here establish two integers will be put in place for the method to utilize
        {
            int newNum = rdm.Next(min, max); //this tells it to use those variables (min & max) and generate a random number from them
            return newNum; //return the newly generated random number
        }
        //Method to add in guest name + their raffle number into our guests dictionary
        private static void AddGuestsInRaffle(int raffleNumber, string guest) //this is set up to mirror our "guest" dict: Dict<int, string>
        {
            guests.Add(raffleNumber, guest); 
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
                randomRaffleNumber = GenerateRandomNumber(min, max); //generate random number between 1000 and 9999
                AddGuestsInRaffle(randomRaffleNumber, otherGuest); //add the inputed name and generated raffle number to dictioanry "guests'
                Console.WriteLine($"The name '{otherGuest}' has been succesfully recorded and their raffle number is {randomRaffleNumber}."); 
                Console.WriteLine("Would you like to enter another name? Enter 'yes' or 'no': "); 
                response1 = Console.ReadLine(); //stores user response so that "while" loop may make decisions on whether to repeat loop or not
            } while (response1 == "yes" || response1 == ""); //continue looping "otherGuest" etc. while the response to "would you like to enter another name" is equal to "yes" or empty
        }

        private static void PrintGuestsName()
        {
            foreach (var personName in guests) //for each instance in our dict guests, run through and list them
            {
                Console.WriteLine(personName); 
            }
        }

        private static int GetRaffleNumber(Dictionary<int, string> guests)
        {
            int index; //arbitrary name, important for our "for" loop below
            int winner; 
            KeyValuePair<int, string> pair; //"pair" is going to hold both the key and value. it is a placeholder name for our dictionary
            for (int i = 0; i < 10; i++) //when i is less than 10, going up from zero, keep looping through and what comes next...
            {
                index = rdm.Next(guests.Count); //make the index int a random number equal to however many key/value pairs are in guests
                pair = guests.ElementAt(index); //our pair identifier is equal to whichever index rdm.Next finds
                winner = pair.Key; //we only want the key right now
                return winner; //so return that key
            }
            return 1;
        }

        private static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests); //call the above method for dictionary "guests". store that into our new integer
            string winnerName = guests[winnerNumber]; //we can use that integer (as a key) to access the value of that indice as well
            Console.WriteLine($"The Winner is: {winnerName} with the raffle #{winnerNumber}"); //finalize writing it all out and we're done!
        }



        //PRINTING EXERCISE BELOW

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            PrintGuestsName();
            PrintWinner();
            Console.ReadLine(); //added this in because my console pop-up window kept closing 
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
