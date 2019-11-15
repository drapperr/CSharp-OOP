using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            IncreasedConst = 0.40;
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override List<Type> AllowedFoods => new List<Type>()
        {
            typeof(Meat),
        };
    }
}
