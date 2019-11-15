using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public double IncreasedConst { get;protected set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (!AllowedFoods.Contains(food.GetType()))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * IncreasedConst;
            FoodEaten += food.Quantity;
        }


        public abstract List<Type> AllowedFoods { get;}
    }
}
