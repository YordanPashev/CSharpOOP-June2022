using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    internal class StationaryPhone : ICallable
    {
        public string MakeACall(string phoneNumber)
        {
            if (phoneNumber.Any(x => char.IsLetter(x)))
            {
                return "Invalid number!";
            }

            return $"Dialing... {phoneNumber}";
        }
    }
}
