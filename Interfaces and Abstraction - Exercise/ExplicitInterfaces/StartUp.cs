using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main()
        {
            List<Citizen> citizens=new List<Citizen>();
            
            string input = string.Empty;

            while ((input=Console.ReadLine())!="End")
            {
                string[] personArgs = input.Split();
                string name = personArgs[0];
                string country = personArgs[1];
                int age = int.Parse(personArgs[2]);

                citizens.Add(new Citizen(name,country,age));
            }

            foreach (var citizen in citizens)
            {
                Console.WriteLine(citizen);
            }
        }
    }
}
