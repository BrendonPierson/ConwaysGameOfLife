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
        private int gridSize;
        private bool changeOnNextTick;
        public bool ChangeOnNextTick;
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
        public Cell(bool alive, int row, int col, int size)
        {
            this.alive = alive;
            changeOnNextTick = false;
            this.row = row;
            this.col = col;
            gridSize = size;
            SetNeighbors();
        }

        public void ChangeAliveProperty()
        {
            alive = alive ? false : true;
        }

        public void SetNeighbors()
        {
            neighbors = new List<List<int>>();
            if (row == 0 && col == 0)
            {
                neighbors.Add(new List<int> { row, col + 1 });
                neighbors.Add(new List<int> { row + 1, col + 1 });
                neighbors.Add(new List<int> { row + 1, col });
            } else if(row == 0 && col == gridSize - 1)
            {
                neighbors.Add(new List<int> { row + 1, col });
                neighbors.Add(new List<int> { row + 1, col - 1 });
                neighbors.Add(new List<int> { row, col - 1 });
            } else if(col == 0 && row == gridSize - 1)
            {
                neighbors.Add(new List<int> { row, col + 1 });
                neighbors.Add(new List<int> { row - 1, col });
                neighbors.Add(new List<int> { row - 1, col + 1 });

            }
            else if(row == gridSize -1 && col == gridSize - 1)
            {
                neighbors.Add(new List<int> { row - 1, col });
                neighbors.Add(new List<int> { row - 1, col - 1 });
                neighbors.Add(new List<int> { row, col - 1 });
            } else if(row == 0)
            {
                neighbors.Add(new List<int> { row + 1, col - 1 });
                neighbors.Add(new List<int> { row,     col - 1 });
                neighbors.Add(new List<int> { row,     col + 1 });
                neighbors.Add(new List<int> { row + 1, col + 1 });
                neighbors.Add(new List<int> { row + 1, col     });
            } else if(col == 0)
            {
                neighbors.Add(new List<int> { row,     col + 1 });
                neighbors.Add(new List<int> { row + 1, col + 1 });
                neighbors.Add(new List<int> { row + 1, col     });
                neighbors.Add(new List<int> { row - 1, col + 1 });
                neighbors.Add(new List<int> { row - 1, col     });
            } else if(row == gridSize - 1)
            {
                neighbors.Add(new List<int> { row,     col - 1 });
                neighbors.Add(new List<int> { row,     col + 1 });
                neighbors.Add(new List<int> { row - 1, col - 1 });
                neighbors.Add(new List<int> { row - 1, col + 1 });
                neighbors.Add(new List<int> { row - 1, col     });
            } else if(col == gridSize - 1)
            {
                neighbors.Add(new List<int> { row + 1, col - 1 });
                neighbors.Add(new List<int> { row,     col - 1 });
                neighbors.Add(new List<int> { row + 1, col     });
                neighbors.Add(new List<int> { row - 1, col     });
                neighbors.Add(new List<int> { row - 1, col - 1 });
            } else
            {
                neighbors.Add(new List<int> { row + 1, col - 1 });
                neighbors.Add(new List<int> { row,     col - 1 });
                neighbors.Add(new List<int> { row,     col + 1 });
                neighbors.Add(new List<int> { row + 1, col + 1 });
                neighbors.Add(new List<int> { row + 1, col     });
                neighbors.Add(new List<int> { row - 1, col - 1 });
                neighbors.Add(new List<int> { row - 1, col + 1 });
                neighbors.Add(new List<int> { row - 1, col     });
            }
        }

    }
}
