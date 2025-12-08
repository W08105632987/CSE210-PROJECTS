using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test individual shapes
            Square square = new Square("Red", 5);
            Rectangle rectangle = new Rectangle("Blue", 4, 6);
            Circle circle = new Circle("Green", 3);

            Console.WriteLine("Testing individual shapes:");
            Console.WriteLine($"Square ({square.GetColor()}): Area = {square.GetArea()}");
            Console.WriteLine($"Rectangle ({rectangle.GetColor()}): Area = {rectangle.GetArea()}");
            Console.WriteLine($"Circle ({circle.GetColor()}): Area = {circle.GetArea()}");

            Console.WriteLine("\nPolymorphism with List<Shape>:\n");

            // Polymorphism in action
            List<Shape> shapes = new List<Shape>();
            shapes.Add(square);
            shapes.Add(rectangle);
            shapes.Add(circle);

            // Loop through shapes and call overridden methods
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"{shape.GetColor()} shape area: {shape.GetArea()}");
            }
        }
    }
}
