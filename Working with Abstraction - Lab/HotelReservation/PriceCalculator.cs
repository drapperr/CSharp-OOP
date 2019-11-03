using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(decimal pricePerDay,int days,Season season,DiscountType discountType)
        {
            decimal result=pricePerDay*days*
            return result
        }
    }
}
