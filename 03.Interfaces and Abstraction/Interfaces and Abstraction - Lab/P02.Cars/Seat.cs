﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; set; }
        public string Color { get; set; }

        public override string ToString() => $"{Color} {GetType().Name} {Model}";

        public string Start() => "Engine start";

        public string Stop() => "Breaaak!";
    }
}
