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
                row.Add( new Cell(false, rowNum, col));
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
        //1. Find number of alive neighbors
        public int NeighborsAlive(int row, int col)
        {
            //For each list in cell.neighbors, find that cell and check if it is living
            int aliveCount = 0;
            List<List<int>> neighbors = cells[row][col].Neighbors;
            foreach(var neighbor in neighbors)
            {
                if (cells[neighbor[0]][neighbor[1]] != null && cells[neighbor[0]][neighbor[1]].Alive) { aliveCount++; }
            }
            return aliveCount;
        }
        //2. Find number of dead neighbors
        //3. Apply rules accordingly







        // From interface
        public void Tick()
        {
            throw new NotImplementedException();
            // Change appropriate Cells
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
