using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main()
        {
            List<IBirthable> population = new List<IBirthable>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(' ');

                string type = inputArgs[0];

                if (type == "Citizen")
                {
                    string name = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    string id = inputArgs[3];
                    string birthdate = inputArgs[4];

                    population.Add(new Citizen(name, age, id, birthdate));
                }
                else if (type == "Pet")
                {
                    string name = inputArgs[1];
                    string birthdate = inputArgs[2];

                    population.Add(new Pet(name, birthdate));
                }
            }

            string specificYear = Console.ReadLine();

            foreach (var p in population.Where(x => x.Birthdate.EndsWith(specificYear)))
            {
                Console.WriteLine(p.Birthdate);
            }
        }
    }
}
