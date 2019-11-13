using System;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private double radius;
        private double rIn;
        private double rOut;

        public Circle(double radius)
        {
            this.radius = radius;
            this.rIn = radius - 0.4;
            this.rOut = radius + 0.4;
        }

        public void Draw()
        {
            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.radius; x < this.rOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
