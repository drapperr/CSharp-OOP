using System;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }

        public double GetSurfaceArea()
        {
            // 2lh + 2wh + 2lw
            double surfaceArea = this.GetLateralSurfaceArea() + 2 * length * width;
            return surfaceArea;
        }
        public double GetLateralSurfaceArea()
        {
            // 2lh + 2wh
            double lateralSurfaceArea = 2 * this.length * this.height + 2 * this.width * this.height;
            return lateralSurfaceArea;
        }
        public double GetVolume()
        {
            // lwh
            double volume = this.length * this.width * this.height;
            return volume;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.GetSurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {this.GetLateralSurfaceArea():F2}");
            sb.Append($"Volume - {this.GetVolume():F2}");
            return sb.ToString();
        }
    }
}
