using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Habitator
    {
        public Habitator(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public bool CheckForFakeId(string fakeIdEndNumber)
        { 
            if (Id.EndsWith(fakeIdEndNumber))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
