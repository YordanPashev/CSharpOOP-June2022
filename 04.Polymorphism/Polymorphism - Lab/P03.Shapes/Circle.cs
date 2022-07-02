﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get => radius; set => radius = value; }

        public override double CalculateArea()
            => Math.PI * Math.Pow(Radius, 2);

        public override double CalculatePerimeter()
            => 2 * Math.PI* radius;

        public override string Draw()
           => base.Draw() + GetType().Name;
    }
}
