using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;
using System.Collections.Generic;

namespace ConwaysGameOfLifeTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void CanCreateGameBoard()
        {
            GameBoard board = new GameBoard(4);
            Assert.IsNotNull(board);
        }

        [TestMethod]
        public void CanCreateTableRowOfCorrectSize()
        {
            GameBoard board = new GameBoard(4);
            Assert.AreEqual(4, board.FillRow(0, 4).Count);
        }

        [TestMethod]
        public void CanCreateBoardWithCorrectNumberOfCells()
        {
            GameBoard board = new GameBoard(10);
            int actual = board.Cells.Count;
            Assert.AreEqual(10, actual);
        }

        [TestMethod]
        public void CanConvertCellsToBools()
        {
            GameBoard board = new GameBoard(10);
            List<List<bool>> boolList = board.CellsToBoolsConverter();
            bool actual = boolList[0][0];
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void CanConvertNthCellToBool()
        {
            GameBoard board = new GameBoard(10);
            board.MakeCellAlive(5, 5);
            List<List<bool>> boolList = board.CellsToBoolsConverter();
            bool actual = boolList[5][5];
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void IsAliveCount1()
        {
            GameBoard board = new GameBoard(10);
            board.MakeCellAlive(5, 5);
            int actual = board.NeighborsAlive(4,5)[0];
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void IsDeadCount7()
        {
            GameBoard board = new GameBoard(10);
            board.MakeCellAlive(5, 5);
            int actual = board.NeighborsAlive(4, 5)[1];
            Assert.AreEqual(7, actual);
        }

        [TestMethod]
        public void ChangeStatusAccordingToRules()
        {
            GameBoard board = new GameBoard(6);
            board.MakeCellAlive(5, 5);
            bool actual = board.ChangeStatus(5, 5, 0, 8);
            Assert.AreEqual(true, actual);
        }
    }
}
