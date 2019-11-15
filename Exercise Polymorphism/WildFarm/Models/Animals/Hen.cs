using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            IncreasedConst = 0.35;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override List<Type> AllowedFoods => new List<Type>()
        {
            typeof(Fruit),
            typeof(Meat),
            typeof(Seeds),
            typeof(Vegetable),
        };
    }
}
