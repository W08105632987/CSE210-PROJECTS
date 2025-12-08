namespace Shapes
{
    public class Shape
    {
        // Encapsulated member variable
        private string _color;

        // Constructor
        public Shape(string color)
        {
            _color = color;
        }

        // Getter and Setter
        public string GetColor()
        {
            return _color;
        }

        public void SetColor(string color)
        {
            _color = color;
        }

        // Virtual method to be overridden
        public virtual double GetArea()
        {
            return 0;
        }
    }
}
