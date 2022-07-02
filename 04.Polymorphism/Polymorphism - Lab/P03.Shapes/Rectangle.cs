using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width { get => width; set => width = value; }

        public double Height { get => height; set => height = value; }

        public override double CalculateArea()
            =>  Width * Height;

        public override double CalculatePerimeter()
            =>  (2 * Width) + (2 * Height);

        public override string Draw()
            => base.Draw() + GetType().Name;
    }
}
