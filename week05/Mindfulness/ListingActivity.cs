using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity(int durationSeconds)
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
               durationSeconds)
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.Write("You will have a few seconds to think. Starting in: ");
        Countdown(5);
        Console.WriteLine();
        Console.WriteLine("Begin listing items. Press Enter after each one.");

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            // If user doesn't type anything and time is up, break; otherwise read line but limit time.
            // Console.ReadLine() is blocking; use a simple approach: check if time remains before ReadLine.
            // We'll allow blocking read, but break if time already passed before the read completes.
            string line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                // treat empty as skip, continue if time remains
                if (DateTime.Now >= endTime) break;
                continue;
            }

            items.Add(line.Trim());
            // If time is up after an input, stop
            if (DateTime.Now >= endTime) break;
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items. Great job!");
        DisplayEndingMessage();
    }
}
