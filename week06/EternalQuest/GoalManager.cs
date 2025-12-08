using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;

        public int Score => _score;

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();

        public void DisplayGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].Display()}");
            }
        }

        public bool RecordEvent(int index)
        {
            if (index < 0 || index >= _goals.Count) return false;
            var goal = _goals[index];
            int gained = goal.RecordEvent();
            _score += gained;
            return true;
        }

        public void Save(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    writer.WriteLine(goal.ToSaveString());
                }
            }
        }

        public void Load(string path)
        {
            _goals.Clear();
            _score = 0;
            if (!File.Exists(path)) return;

            var lines = File.ReadAllLines(path);
            if (lines.Length == 0) return;

            // First line is score
            if (int.TryParse(lines[0], out int parsedScore))
                _score = parsedScore;

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var goal = ParseGoalLine(line);
                if (goal != null)
                    _goals.Add(goal);
            }
        }

        private Goal ParseGoalLine(string line)
        {
            // Handle escaped '|' characters (simple approach)
            // We'll split on '|' but consider simple escaped pipe \|
            var parts = SplitPreserveEscapes(line);
            if (parts.Length == 0) return null;
            var type = parts[0];

            try
            {
                switch (type)
                {
                    case "Simple":
                        // Simple|Name|Description|Points|Completed
                        return new SimpleGoal(Unescape(parts[1]), Unescape(parts[2]), int.Parse(parts[3]), bool.Parse(parts[4]));
                    case "Eternal":
                        // Eternal|Name|Description|Points
                        return new EternalGoal(Unescape(parts[1]), Unescape(parts[2]), int.Parse(parts[3]));
                    case "Checklist":
                        // Checklist|Name|Description|PointsPer|TargetCount|Bonus|CurrentCount
                        return new ChecklistGoal(
                            Unescape(parts[1]),
                            Unescape(parts[2]),
                            int.Parse(parts[3]),
                            int.Parse(parts[4]),
                            int.Parse(parts[5]),
                            int.Parse(parts[6])
                            );
                    default:
                        return null;
                }
            }
            catch
            {
                return null;
            }
        }

        private string[] SplitPreserveEscapes(string s)
        {
            var parts = new List<string>();
            var current = "";
            bool escaping = false;
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (escaping)
                {
                    // allow escaping '|'
                    if (c == '|') current += '|';
                    else current += c;
                    escaping = false;
                }
                else
                {
                    if (c == '\\')
                    {
                        escaping = true;
                    }
                    else if (c == '|')
                    {
                        parts.Add(current);
                        current = "";
                    }
                    else
                    {
                        current += c;
                    }
                }
            }
            parts.Add(current);
            return parts.ToArray();
        }

        private string Unescape(string s) => s.Replace("\\|", "|");
    }
}
