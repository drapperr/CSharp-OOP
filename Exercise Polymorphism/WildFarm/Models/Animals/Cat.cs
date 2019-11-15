using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            IncreasedConst = 0.30;
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override List<Type> AllowedFoods => new List<Type>()
        {
            typeof(Meat),
            typeof(Vegetable),
        };
    }
}
