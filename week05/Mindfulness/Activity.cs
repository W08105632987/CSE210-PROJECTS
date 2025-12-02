using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;

    public Activity(string name, string description, int durationSeconds)
    {
        _name = name;
        _description = description;
        _durationSeconds = durationSeconds;
    }

    // Expose duration to derived classes (read-only)
    protected int DurationSeconds => _durationSeconds;

    protected string Name => _name;

    // Standard starting message shown by every activity
    public virtual void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"=== {_name} ===");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine($"This session will last {_durationSeconds} seconds.");
        Console.WriteLine();
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(3); // pause for several seconds with spinner
        Console.WriteLine();
    }

    // Standard end message shown by every activity
    public virtual void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name} for {_durationSeconds} seconds.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    // Basic spinner animation for 'seconds' seconds
    protected void ShowSpinner(int seconds)
    {
        char[] sequence = new char[] { '|', '/', '-', '\\' };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int idx = 0;
        while (DateTime.Now < end)
        {
            Console.Write(sequence[idx % sequence.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
            idx++;
        }
    }

    // Countdown display (seconds to 1)
    protected void Countdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // remove previous number
        }
    }

    // Derived classes must implement Run
    public abstract void Run();
}
