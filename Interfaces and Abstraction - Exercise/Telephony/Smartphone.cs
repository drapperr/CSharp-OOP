using System;

namespace Telephony
{
    public class Smartphone:ICallable,IBrowseble
    {
        public Smartphone(string model)
        {
            this.Model = model;
        }

        public string Model { get; set; }

        public void Browse(string site)
        {
            foreach (var ch in site)
            {
                if (char.IsDigit(ch))
                {
                    Console.WriteLine("Invalid URL!");
                    return;
                }
            }

            Console.WriteLine($"Browsing: {site}!");
        }

        public void Call(string number)
        {
            foreach (var ch in number)
            {
                if (!char.IsDigit(ch))
                {
                    Console.WriteLine("Invalid number!");
                    return;
                }
            }

            Console.WriteLine($"Calling... {number}");
        }
    }
}
