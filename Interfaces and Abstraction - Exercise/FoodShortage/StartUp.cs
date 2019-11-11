using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input.Length==3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    buyers.Add(name, new Rebel(name, age, group));
                }
                else
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];

                    buyers.Add(name, new Citizen(name, age, id, birthdate));
                }
            }

            string buyerName = string.Empty;

            while ((buyerName=Console.ReadLine())!="End")
            {
                if (buyers.ContainsKey(buyerName))
                {
                    buyers[buyerName].BuyFood();
                }
            }

            int totoalFood = buyers.Sum(x => x.Value.Food);

            Console.WriteLine(totoalFood);  ;
        }
    }   
}
