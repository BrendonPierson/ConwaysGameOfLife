using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConwaysGameOfLife
{
    public class GameBoard : Board
    {
        // private List<List<bool>> cells;
        private List<List<Cell>> cells;
        private int size;

        public List<List<Cell>> Cells
        {
            get { return cells; }
        }

        // Game board constructor function
        public GameBoard(int size)
        {
            this.size = size;
            cells = new List<List<Cell>>(size);
            for (int i = 0; i < size; i++)
            {
                cells.Add( FillRow(i, size) );
            }
        }

        // Helper function to fill up rows when board is created
        public List<Cell> FillRow(int rowNum, int size)
        {
            List<Cell> row = new List<Cell>();
            for(var col = 0; col < size; col++)
            {
                row.Add( new Cell(false, rowNum, col, size));
            }
            return row;
        }

        // take coordinates and make that cell alive
        public void MakeCellAlive(int col, int row)
        {
            cells[row][col].Alive = true;
        }
        // Kill cell from coordinates
        public void KillCell(int col, int row)
        {
            cells[row][col].Alive = false;
        }

        // For each cell
        public void CheckAllCells()
        {
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    cells[r][c].ChangeOnNextTick = false;
                    int aliveCount = NeighborsAlive(r, c)[0];
                    int deadCount = NeighborsAlive(r, c)[1];
                    ChangeStatus(r, c, aliveCount, deadCount);
                }
            }
        }
        //1. Find number of alive neighbors
        //2. Find number of dead neighbors
        public int[] NeighborsAlive(int row, int col)
        {
            int aliveCount = 0;
            int deadCount = 0;
            List<List<int>> neighbors = cells[row][col].Neighbors;
            foreach (var neighbor in neighbors)
            {
                if (cells[neighbor[0]][neighbor[1]].Alive)
                {
                    aliveCount++;
                }
                if (!cells[neighbor[0]][neighbor[1]].Alive)
                {
                    deadCount++;
                }
             }
            return new int[] { aliveCount, deadCount };
        }

        //3. Apply rules accordingly
        public bool ChangeStatus(int row, int col, int aliveCount, int deadCount)
        {
            if (cells[row][col].Alive && aliveCount < 2 || aliveCount > 3)
            {
                cells[row][col].ChangeOnNextTick = true;
                return true;
            }
            if (!cells[row][col].Alive && aliveCount == 3)
            {
                cells[row][col].ChangeOnNextTick = true;
                return true;
            }
            return false;
        }

        // Change colors once all cells are checked
        public void ChangeColors()
        {
            for(int r = 0; r < size; r++)
            {
                for(int c = 0; c < size; c++)
                {
                    if (cells[r][c].ChangeOnNextTick)
                    {
                        cells[r][c].Alive = cells[r][c].Alive ? false : true;
                    }
                    //if (cells[r][c].ChangeOnNextTick)
                    //{
                    //    cells[r][c].ChangeAliveProperty();
                    //}
                }
            }
        }

        // From interface
        public void Tick()
        {
            CheckAllCells();
            ChangeColors();
        }

        // used to create list format necessary for visualizer
        public List<bool> DecodeRow(int rowNum, int size)
        {
            List<bool> row = new List<bool>();
            for (var col = 0; col < size; col++)
            {
                row.Add(cells[rowNum][col].Alive);
            }
            return row;
        }
        public List<List<bool>> CellsToBoolsConverter()
        {
            List<List<bool>> boolList = new List<List<bool>>();
            for (int r = 0; r < size; r++)
            {
                boolList.Add(DecodeRow(r, size));
            }
            return boolList;
        }

        public List<List<bool>> ToList()
        {
            return CellsToBoolsConverter();
        }
    }
}
