using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity(int durationSeconds)
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
               durationSeconds)
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        // We'll alternate "Breathe in..." and "Breathe out..." with short countdowns.
        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            // give 4 seconds to breathe in (or remaining time if less)
            int inSec = Math.Min(4, (int)(endTime - DateTime.Now).TotalSeconds);
            if (inSec <= 0) break;
            Countdown(inSec);

            Console.WriteLine();
            Console.Write("Breathe out...");
            int outSec = Math.Min(6, (int)(endTime - DateTime.Now).TotalSeconds); // slightly longer out
            if (outSec <= 0) break;
            Countdown(outSec);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
