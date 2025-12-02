using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1) Breathing Activity");
            Console.WriteLine("2) Reflecting Activity");
            Console.WriteLine("3) Listing Activity");
            Console.WriteLine("4) Exit");
            Console.WriteLine();
            Console.Write("Choose an activity (1-4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunActivity(() => {
                        int d = PromptForDuration();
                        var a = new BreathingActivity(d);
                        a.Run();
                        LogActivity(a);
                    });
                    break;
                case "2":
                    RunActivity(() => {
                        int d = PromptForDuration();
                        var a = new ReflectingActivity(d);
                        a.Run();
                        LogActivity(a);
                    });
                    break;
                case "3":
                    RunActivity(() => {
                        int d = PromptForDuration();
                        var a = new ListingActivity(d);
                        a.Run();
                        LogActivity(a);
                    });
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }
        }

        Console.WriteLine("Goodbye. Press Enter to close.");
        Console.ReadLine();
    }

    static void RunActivity(Action action)
    {
        action();
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }

    static int PromptForDuration()
    {
        while (true)
        {
            Console.Write("Enter the duration in seconds for the activity: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                return seconds;
            }
            Console.WriteLine("Please enter a positive integer number of seconds.");
        }
    }

    static void LogActivity(Activity activity)
    {
        try
        {
            string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {activity.GetType().Name} | {GetDuration(activity)}s";
            File.AppendAllText("activity_log.txt", logLine + Environment.NewLine);
        }
        catch
        {
            // Logging is best-effort; do not crash program if logging fails
        }
    }

    // Access duration using reflection because DurationSeconds is protected in base class.
    static int GetDuration(Activity activity)
    {
        var t = activity.GetType().BaseType ?? activity.GetType();
        // Search for property DurationSeconds via protected getter (it returns int)
        var prop = activity.GetType().GetProperty("DurationSeconds", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy);
        if (prop != null)
        {
            object val = prop.GetValue(activity);
            if (val is int i) return i;
        }

        // fallback: attempt to read private field (not ideal)
        return 0;
    
    }
}