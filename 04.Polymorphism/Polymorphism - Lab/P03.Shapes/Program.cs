using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Shape circle = new Circle(5);
            Shape rectangle = new Rectangle(5, 2);

            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());

            Console.WriteLine(circle.Draw());
            Console.WriteLine(rectangle.Draw());
        }
    }
}
