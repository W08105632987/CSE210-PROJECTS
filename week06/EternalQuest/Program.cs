using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var manager = new GoalManager();
            var savePath = "goals.txt";

            Console.WriteLine("=== Eternal Quest ===");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine($"Score: {manager.Score}  (Level {ComputeLevel(manager.Score)})");
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Show Badges");
                Console.WriteLine("7. Quit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGoalFlow(manager);
                        break;
                    case "2":
                        manager.DisplayGoals();
                        break;
                    case "3":
                        manager.DisplayGoals();
                        Console.Write("Enter goal number to record (or 0 to cancel): ");
                        if (int.TryParse(Console.ReadLine(), out int num) && num > 0)
                        {
                            if (manager.RecordEvent(num - 1))
                                Console.WriteLine("Event recorded!");
                            else
                                Console.WriteLine("Invalid goal number.");
                        }
                        break;
                    case "4":
                        manager.Save(savePath);
                        Console.WriteLine($"Saved to {savePath}");
                        break;
                    case "5":
                        manager.Load(savePath);
                        Console.WriteLine($"Loaded from {savePath}");
                        break;
                    case "6":
                        ShowBadges(manager.Score);
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }

        static void CreateGoalFlow(GoalManager manager)
        {
            Console.WriteLine("Choose type:");
            Console.WriteLine("1. Simple Goal (one-time)");
            Console.WriteLine("2. Eternal Goal (repeatable)");
            Console.WriteLine("3. Checklist Goal (finish N times)");
            Console.Write("Choice: ");
            var type = Console.ReadLine();

            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Description: ");
            var desc = Console.ReadLine();
            Console.Write("Points (integer): ");
            if (!int.TryParse(Console.ReadLine(), out int points)) points = 0;

            switch (type)
            {
                case "1":
                    var sg = new SimpleGoal(name, desc, points);
                    manager.AddGoal(sg);
                    Console.WriteLine("Simple goal created.");
                    break;
                case "2":
                    var eg = new EternalGoal(name, desc, points);
                    manager.AddGoal(eg);
                    Console.WriteLine("Eternal goal created.");
                    break;
                case "3":
                    Console.Write("Target count (e.g., 10): ");
                    if (!int.TryParse(Console.ReadLine(), out int target)) target = 1;
                    Console.Write("Bonus points when completed: ");
                    if (!int.TryParse(Console.ReadLine(), out int bonus)) bonus = 0;
                    var cg = new ChecklistGoal(name, desc, points, target, bonus);
                    manager.AddGoal(cg);
                    Console.WriteLine("Checklist goal created.");
                    break;
                default:
                    Console.WriteLine("Invalid type.");
                    break;
            }
        }

        static int ComputeLevel(int score)
        {
            // Very simple leveling: every 500 points is a level
            return (score / 500) + 1;
        }

        static void ShowBadges(int score)
        {
            Console.WriteLine("Badges:");
            if (score >= 5000) Console.WriteLine("- Eternal Master (5000 pts)");
            if (score >= 2500) Console.WriteLine("- Quest Veteran (2500 pts)");
            if (score >= 1000) Console.WriteLine("- Achiever (1000 pts)");
            if (score < 1000) Console.WriteLine("- Getting Started (less than 1000 pts)");
        }
    }
}
