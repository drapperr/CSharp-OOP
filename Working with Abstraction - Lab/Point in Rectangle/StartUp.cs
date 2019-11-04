using System;
using System.Linq;

namespace PointInRectangle
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //"{topLeftX} {topLeftY} {bottomRightX} {bottomRightY}"
            int[] rectanglePoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int topLeftX = rectanglePoints[0];
            int topLeftY = rectanglePoints[1];
            int bottomRightX = rectanglePoints[2];
            int bottomRightY = rectanglePoints[3];

            Point topLeft = new Point(topLeftX, topLeftY);
            Point bottomRight = new Point(bottomRightX, bottomRightY);

            Rectangle rectangle = new Rectangle(topLeft, bottomRight);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] pointCoordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                int x = pointCoordinates[0];
                int y = pointCoordinates[1];

                Point point = new Point(x, y);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
