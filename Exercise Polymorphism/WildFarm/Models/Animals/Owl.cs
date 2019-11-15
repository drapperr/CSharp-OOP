using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            IncreasedConst = 0.25;
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override List<Type> AllowedFoods => new List<Type>()
        {
            typeof(Meat),
        };
    }
}
