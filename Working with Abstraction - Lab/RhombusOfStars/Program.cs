using System;
using System.Text;

namespace RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            DrawRhombusOnConsole(size);
        }

        private static void DrawRhombusOnConsole(int size)
        {
            var rhombus = new StringBuilder();

            DrawTop(rhombus, size);
            DrawMid(rhombus, size);
            DrawBottom(rhombus, size);

            Console.WriteLine(rhombus.ToString().TrimEnd());
        }

        public static void DrawLine(StringBuilder rhombus, int size)
        {
            for (int j = 1; j <= size; j++)
            {
                rhombus.Append('*');
                if (j != size)
                {
                    rhombus.Append(' ');
                }
            }
            rhombus.AppendLine();
        }
        public static void DrawTop(StringBuilder rhombus, int size)
        {
            for (int i = 1; i < size; i++)
            {
                rhombus.Append(new string(' ', size - i));
                DrawLine(rhombus, i);
            }
        }
        public static void DrawMid(StringBuilder rhombus, int size)
        {
            DrawLine(rhombus, size);
        }
        public static void DrawBottom(StringBuilder rhombus, int size)
        {
            for (int i = size - 1; i >= 1; i--)
            {
                rhombus.Append(new string(' ', size - i));
                DrawLine(rhombus, i);
            }
        }
    }
}
