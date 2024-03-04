using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 11);
        int attempts = 0;
        bool guessedCorrectly = false;

        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("I have selected a number between 1 and 10. Try to guess it!");

        while (!guessedCorrectly)
        {
            Console.Write("Enter your guess: ");
            int guess = Convert.ToInt32(Console.ReadLine());

            attempts++;

            if (guess == secretNumber)
            {
                Console.WriteLine($"Congratulations! You've guessed the number {secretNumber} correctly in {attempts} attempts!");
                guessedCorrectly = true;
            }
            else
            {
                Console.WriteLine("Sorry, that's not the correct number. Try again!");
            }
        }

        Console.WriteLine("Thank you for playing!");
    }
}
