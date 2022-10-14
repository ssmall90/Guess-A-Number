using System;
using System.Linq;


namespace Guess_A_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask user to pick think of a number between 0-100
            Console.WriteLine("I want you to think of a number between 0-100 OK?");
            Console.ReadLine();

            //Define max number user can guess
            int max = 100;

            //Keep track of number of guesses
            int guesses = 0;

            //The start guess from
            int guessMin = 0;

            //The start guess to (half of max)
            int guessMax = max / 2;

            //While the guess isnt the same as the known maxiumum value 
            while (guessMin != max)
            {
                //Increase guess amount (by 1)
                guesses++;

                //Ask the user if their number is between the guess range 
                Console.WriteLine($"Is your number between {guessMin} and {guessMax}");

                string response = Console.ReadLine();

                // If the user confirmed their number is in the current range..

                if (response?.ToLower().FirstOrDefault() == 'y' )
                {
                    Console.WriteLine($"You answered Yes");
                    //We know number is between guessFrom and guessTo (0-50)
                    //So set new maximum number 
                    max = guessMax;

                    //Change the next guess range to be half of the new maximum range
                    guessMax = guessMax - (guessMax - guessMin) / 2;

                }
                //The number is greater than guessMax and less than or equal to man
                else
                {
                    Console.WriteLine($"You answered No");
                    //The new minimum is one above the old maximum
                    guessMin = guessMax + 1;

                    //Guess the bottom half of the new range 
                    int remainingDifference = max - guessMax;

                    //Set the guess max to halfway between guessMin and max
                    //NOTE: Math ceiling will round up the remaining difference to 2 if the difference is 3
                    guessMax += (int)Math.Ceiling(remainingDifference / 2f);
                
                }

                //If we only have 2 numbers left guess one of then 
                if(guessMin + 1 == max)
                {
                    guesses++;

                    //Ask the user is their number is the lower number 
                    Console.WriteLine($"Is your number {guessMin}");
                    response = Console.ReadLine();

                    //If user confirms their number is the lower number 
                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;
                    }
                    else
                    {
                        //That means the number must be the higher of the 2
                        guessMin = max;
                        break;
                    }

                }
            }
            //Tell the user their number
            Console.WriteLine($"**Your number is {guessMin}**");

            //Let the user know how many guess it took
            Console.WriteLine($"It took {guesses} attempts to guess your number");

            Console.ReadLine();
        }
    }
}
