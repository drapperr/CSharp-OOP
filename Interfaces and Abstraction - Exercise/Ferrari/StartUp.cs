using System;

namespace Ferrari
{
    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();

            Ferrari ferrari = new Ferrari(name);

            Console.WriteLine(ferrari);
        }
    }
}
