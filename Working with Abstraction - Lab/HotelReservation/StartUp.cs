using System;

namespace HotelReservation
{
    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();

            decimal pricePerDay = decimal.Parse(input[0]);
            int days = int.Parse(input[1]);
            string season = input[2];
            string discountType = "None";

            if (input.Length==4)
            {
                discountType = input[3];
            }

            decimal result = PriceCalculator.GetTotalPrice(pricePerDay, days,Season.days, discountType);
        }
    }
}
