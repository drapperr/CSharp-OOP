using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main()
        {
            string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string,Person> people = new Dictionary<string,Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            try
            {
                foreach (var person in peopleInput)
                {
                    string[] personArgs = person.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = personArgs[0];
                    decimal money = decimal.Parse(personArgs[1]);

                    if (!people.ContainsKey(name))
                    {
                        people.Add(name, new Person(name, money));
                    }
                }

                foreach (var product in productsInput)
                {
                    string[] productArgs = product.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = productArgs[0];
                    decimal cost = decimal.Parse(productArgs[1]);

                    if (!products.ContainsKey(name))
                    {
                        products.Add(name, new Product(name, cost));
                    }
                }
                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] inputArgs = input.Split(' ');
                    string personName = inputArgs[0];
                    string productName = inputArgs[1];

                    people[personName].BuyProduct(products[productName]);
                }

                foreach (var (name, person) in people)
                {
                    Console.Write($"{name} - ");

                    if (person.BagOfProducts.Count == 0)
                    {
                        Console.WriteLine("Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine(string.Join(", ", person));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
