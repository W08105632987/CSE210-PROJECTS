using System;

namespace EternalQuest
{
    // Base abstract class for all goals
    public abstract class Goal
    {
        // Encapsulated member variables
        private string _name;
        private string _description;
        private int _points;

        // Constructor
        protected Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        // Public getters (read-only)
        public string Name => _name;
        public string Description => _description;
        public int Points => _points;

        // RecordEvent returns points awarded from this event (0 if none)
        public abstract int RecordEvent();

        // Display the goal status (polymorphic)
        public abstract string Display();

        // Whether the goal is currently considered complete (for Simple/Checklist)
        public abstract bool IsComplete();

        // Serialize to string for saving
        public abstract string ToSaveString();

        // Factory: create from save line (handled by GoalFactory/GoalManager)
    }
}
