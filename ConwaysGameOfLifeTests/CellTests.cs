using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;
using System.Collections.Generic;

namespace ConwaysGameOfLifeTests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void CanCreateCell()
        {
            Cell cell = new Cell(false,0,0,10);
            Assert.IsNotNull(cell);
        }

        [TestMethod]
        public void CellHasAliveProperty()
        {
            Cell cell = new Cell(false, 1, 0,10);
            Assert.AreEqual(false, cell.Alive);
        }

        [TestMethod]
        public void CellHasColProperty()
        {
            Cell cell = new Cell(false, 1, 0,10);
            Assert.AreEqual(0, cell.Col);
        }

        [TestMethod]
        public void CellHasRowProperty()
        {
            Cell cell = new Cell(false, 5, 0,10);
            Assert.AreEqual(5, cell.Row);
        }

        [TestMethod]
        public void CellHasNeighbors()
        {
            Cell cell = new Cell(false, 0, 0,10);
            Assert.IsNotNull(cell.Neighbors);
        }

        [TestMethod]
        public void CellHasCorrectNumberOfNeighbors()
        {
            Cell cell = new Cell(false, 4, 4,10);
            Assert.AreEqual(8, cell.Neighbors.Count);
        }


    }
}
