using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            IncreasedConst = 1.00;
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override List<Type> AllowedFoods => new List<Type>()
        {
            typeof(Meat),
        };
    }
}
