using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _completed;

        public SimpleGoal(string name, string description, int points, bool completed = false)
            : base(name, description, points)
        {
            _completed = completed;
        }

        public override int RecordEvent()
        {
            if (_completed)
                return 0; // already completed, no points
            _completed = true;
            return Points; // award points once
        }

        public override string Display()
        {
            string box = _completed ? "[X]" : "[ ]";
            return $"{box} {Name} ({Description}) - {Points} pts";
        }

        public override bool IsComplete() => _completed;

        public override string ToSaveString()
        {
            // Type|Name|Description|Points|Completed
            return $"Simple|{Escape(Name)}|{Escape(Description)}|{Points}|{_completed}";
        }

        private string Escape(string s) => s.Replace("|", "\\|");
    }
}
