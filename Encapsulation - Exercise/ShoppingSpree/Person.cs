using System;
using System.Collections;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person : IEnumerable<string>
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public IReadOnlyCollection<Product> BagOfProducts => bagOfProducts.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                Console.WriteLine($"{this.name} can't afford {product.Name}");
            }
            else
            {
                this.money -= product.Cost;
                bagOfProducts.Add(product);
                Console.WriteLine($"{this.name} bought {product.Name}");
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (var product in this.bagOfProducts)
            {
                yield return product.Name;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
