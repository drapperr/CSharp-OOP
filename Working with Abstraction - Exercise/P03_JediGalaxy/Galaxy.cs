using System;
using System.Collections.Generic;
using System.Text;

namespace P03_JediGalaxy
{
    public class Galaxy
    {
        public Galaxy(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.matrix = new int[row, col];
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int[,] matrix { get; set; }
    }
}
