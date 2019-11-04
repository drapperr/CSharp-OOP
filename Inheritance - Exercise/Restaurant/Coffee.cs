namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50m;

        public Coffee(string name, decimal price= CoffeePrice, double milliliters= CoffeeMilliliters) 
            : base(name, price, milliliters)
        {
        }

        public double Caffeine  { get; set; }
    }
}
