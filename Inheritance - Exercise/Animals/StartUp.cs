using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            Animal animal;

            List<Animal> animals = new List<Animal>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                try
                {
                    switch (input)
                    {
                        case "Dog":
                            animal = new Dog(name, age, gender);
                            break;
                        case "Cat":
                            animal = new Cat(name, age, gender);
                            break;
                        case "Frog":
                            animal = new Frog(name, age, gender);
                            break;
                        case "Kitten":
                            animal = new Kitten(name, age);
                            break;
                        case "Tomcat":
                            animal = new Tomcat(name, age);
                            break;
                        default:
                            throw new Exception("Invalid input!");
                    }
                    animals.Add(animal);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var currentAnimal in animals)
            {
                Console.WriteLine(currentAnimal);
            }
        }
    }
}
