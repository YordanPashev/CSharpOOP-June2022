using System;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
           string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
           string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
           Smartphone smartphone = new Smartphone();
           StationaryPhone stationaryPhone = new StationaryPhone();


            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 10)
                {
                    Console.WriteLine(smartphone.MakeACall(phoneNumber));
                }

                else if (phoneNumber.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.MakeACall(phoneNumber));
                }
            }

            foreach (string url in urls)
            {
                Console.WriteLine(smartphone.Browse(url));
            }

        }
    }
}
