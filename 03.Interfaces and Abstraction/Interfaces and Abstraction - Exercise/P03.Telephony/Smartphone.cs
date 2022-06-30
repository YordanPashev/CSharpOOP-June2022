using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                return"Invalid URL!";
            }

            return $"Browsing: {url}!";
        }

        public string MakeACall(string phoneNumber)
        {
            if (phoneNumber.Any(x => char.IsLetter(x)))
            {
                return "Invalid number!";
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
