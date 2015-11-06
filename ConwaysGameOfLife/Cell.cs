using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        private bool alive;
        private int row;
        private int col;
        private List<List<int>> neighbors;

        // Unclear why Row needs explicite setter/getter but col doesn't?
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        public int Col;
        public List<List<int>> Neighbors
        {
            get { return neighbors; }
            set { neighbors = value; }
        }
        public bool Alive;

        // Cell constructor
        public Cell(bool alive, int row, int col)
        {
            this.alive = alive;
            this.row = row;
            this.col = col;
            SetNeighbors();
        }

        public void SetNeighbors()
        {
            neighbors = new List<List<int>>(8);
            neighbors.Add(new List<int> { col - 1, row - 1 });
            neighbors.Add(new List<int> { col - 1, row + 1 });
            neighbors.Add(new List<int> { col - 1, row });
            neighbors.Add(new List<int> { col + 1, row });
            neighbors.Add(new List<int> { col + 1, row - 1 });
            neighbors.Add(new List<int> { col + 1, row + 1 });
            neighbors.Add(new List<int> { col, row - 1 });
            neighbors.Add(new List<int> { col, row + 1 });
        }

    }
}
