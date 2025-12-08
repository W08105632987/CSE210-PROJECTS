using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int pointsPerCompletion, int targetCount, int bonusPoints, int currentCount = 0)
            : base(name, description, pointsPerCompletion)
        {
            _targetCount = targetCount;
            _currentCount = currentCount;
            _bonusPoints = bonusPoints;
        }

        public override int RecordEvent()
        {
            if (_currentCount >= _targetCount)
                return 0; // already finished

            _currentCount++;
            int awarded = Points;
            if (_currentCount == _targetCount)
            {
                // award bonus when completed
                awarded += _bonusPoints;
            }
            return awarded;
        }

        public override string Display()
        {
            string status = _currentCount >= _targetCount ? "[X]" : "[ ]";
            return $"{status} {Name} ({Description}) - {Points} pts each ({_currentCount}/{_targetCount}) Bonus: {_bonusPoints} pts";
        }

        public override bool IsComplete() => _currentCount >= _targetCount;

        public override string ToSaveString()
        {
            // Type|Name|Description|PointsPer|TargetCount|Bonus|CurrentCount
            return $"Checklist|{Escape(Name)}|{Escape(Description)}|{Points}|{_targetCount}|{_bonusPoints}|{_currentCount}";
        }

        private string Escape(string s) => s.Replace("|", "\\|");
    }
}
