using System;

namespace Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            string[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] sites = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new Smartphone("Samsung");

            foreach (var number in numbers)
            {
                smartphone.Call(number);
            }

            foreach (var site in sites)
            {
                smartphone.Browse(site);
            }
        }
    }
}
