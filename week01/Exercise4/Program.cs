using System;


class Program
{
    static void Main(string[] args)
    {
        
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            // Validate input
            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
                continue;
            }

            // Stop on 0 (do not add 0 to the list)
            if (value == 0) break;

            numbers.Add(value);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        // Core requirements computed step-by-step:

        // 1) Sum
        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }

        // 2) Average (use double for precision)
        double average = (double)sum / numbers.Count;

        // 3) Largest number
        int largest = numbers[0];
        foreach (int n in numbers)
        {
            if (n > largest) largest = n;
        }

        // Output results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");




    }
}