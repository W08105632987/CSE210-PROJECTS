using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("What is the Magic Number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        int Guess;

        do
        {
            Console.Write("Guess is the Magic number? ");
            Guess = int.Parse(Console.ReadLine());

            if (magicNumber > Guess)
                Console.WriteLine("Too low, Try again");
            else if (magicNumber < Guess)
                Console.WriteLine("Too high, Try again");
        } while (magicNumber != Guess);

        Console.Write("Congratulations you have guessed the number ");
        
    }
}