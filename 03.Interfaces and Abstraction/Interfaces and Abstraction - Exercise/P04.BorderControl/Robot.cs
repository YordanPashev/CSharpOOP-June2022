using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : Habitator
    {
        public Robot(string model, string id) : base (id)
        {
            Model = model;
        }

        public string Model { get; set; }

    }
}
