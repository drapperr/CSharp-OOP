using System;

namespace ExplicitInterfaces
{
    public class Citizen:IPerson,IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }
        public string Name { get; }

        public string Country { get; }

        public int Age { get; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }

        string IPerson.GetName()
        {
            return this.Name;
        }

        public override string ToString()
        {
            return $"{this.Name}{Environment.NewLine}Mr/Ms/Mrs {this.Name}";
        }
    }
}
