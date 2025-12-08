using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        { }

        public override int RecordEvent()
        {
            // Can be recorded repeatedly; never completes
            return Points;
        }

        public override string Display()
        {
            return $"[~] {Name} ({Description}) - {Points} pts each time (Eternal)";
        }

        public override bool IsComplete() => false;

        public override string ToSaveString()
        {
            // Type|Name|Description|Points
            return $"Eternal|{Escape(Name)}|{Escape(Description)}|{Points}";
        }

        private string Escape(string s) => s.Replace("|", "\\|");
    }
}
