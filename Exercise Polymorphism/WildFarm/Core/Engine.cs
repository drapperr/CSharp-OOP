using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine
    {
        public void Run()
        {
            List<Animal> animals=new List<Animal>();
            
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInfo = input.Split();
                string type = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                Animal animal = null;

                if (type == "Owl")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    animal = new Owl(name, weight, wingSize);
                }
                else if (type == "Hen")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    animal = new Hen(name, weight, wingSize);
                }
                else if (type == "Mouse")
                {
                    string livingRegion = animalInfo[3];
                    animal = new Mouse(name, weight, livingRegion);
                }
                else if (type == "Dog")
                {
                    string livingRegion = animalInfo[3];
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (type == "Cat")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else if (type == "Tiger")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                }

                string[] foodInfo = Console.ReadLine().Split();
                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                Food food = null;

                switch (foodType)
                {
                    case "Fruit":
                        food = new Fruit(quantity);
                        break;
                    case "Meat":
                        food = new Meat(quantity);
                        break;
                    case "Seeds":
                        food = new Seeds(quantity);
                        break;
                    case "Vegetable":
                        food = new Vegetable(quantity);
                        break;
                }

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
