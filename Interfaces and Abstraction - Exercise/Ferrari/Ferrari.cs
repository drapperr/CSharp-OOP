using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : IFerrari
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
            this.Model = "488-Spider";
        }

        public string Model { get; set; }
        public string Driver { get; set; }

        public string PushTheGasPedal()
        {
            return "Gas!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{UseBrakes()}/{PushTheGasPedal()}/{this.Driver} "; 
        }
    }
}
