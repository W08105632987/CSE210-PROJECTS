using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("What is your Score? ");
        int Score = int.Parse(Console.ReadLine());

        string LetterGrade = "";

        if (Score >= 90)
        {
            LetterGrade = "A";
        }
        else if (Score >= 80)
        {
            LetterGrade = "B";
        }
        else if (Score >= 70)
        {
            LetterGrade = "C";
        }
        else if (Score >= 60)
        {
            LetterGrade = "D";
        }
        else
        {
            LetterGrade = "F";
        }

        Console.WriteLine("Your Grade is: " + LetterGrade);

        if (Score >= 70)
        {
            Console.WriteLine("Congratulations! You Passed the Course");
        }
        else
        {
            Console.WriteLine("Nice effort but unfortunately you Failed the Course, try again next time.");
        }
    }
}