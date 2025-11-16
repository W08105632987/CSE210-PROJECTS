using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");

        // Create fractions using all three constructors
        Fraction f1 = new Fraction();        // Should create 1/1
        Fraction f2 = new Fraction(5);       // Should create 5/1
        Fraction f3 = new Fraction(3, 4);    // Should create 3/4
        Fraction f4 = new Fraction(1, 3);    // Should create 1/3

        // Display each fraction string and decimal value
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());
    }
}


