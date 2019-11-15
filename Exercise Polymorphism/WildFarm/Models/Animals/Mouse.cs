using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            IncreasedConst = 0.10;
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override List<Type> AllowedFoods => new List<Type>()
        {
            typeof(Fruit),
            typeof(Vegetable),
        };
    }
}
