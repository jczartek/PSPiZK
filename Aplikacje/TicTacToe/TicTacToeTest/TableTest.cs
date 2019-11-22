using System;
using TicTacToe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToeTest
{
    [TestClass]
    public class TableTest
    {
        [TestMethod]
        public void TestDiagonals()
        {
            Engine engine = new Engine();

            Assert.AreEqual(false, engine.IsFinished);

            engine[0, 0] = 'X';
            engine[1, 1] = 'X';
            engine[2, 2] = 'X';

            Assert.AreEqual(true, engine.IsFinished);
            Assert.AreEqual("X", engine.Winer);

            engine.Reset();

            engine[2, 0] = 'O';
            engine[1, 1] = 'O';
            engine[0, 2] = 'O';

            Assert.AreEqual(true, engine.IsFinished);
            Assert.AreEqual("O", engine.Winer);
        }

        [TestMethod]
        public void TestRows()
        {
            Engine engine = new Engine();

            engine[0, 0] = 'X';
            engine[0, 1] = 'X';
            engine[0, 2] = 'X';

            Assert.AreEqual(true, engine.IsFinished);
            Assert.AreEqual("X", engine.Winer);

            engine.Reset();

            engine[1, 0] = 'X';
            engine[1, 1] = 'X';
            engine[1, 2] = 'X';

            Assert.AreEqual(true, engine.IsFinished);
            Assert.AreEqual("X", engine.Winer);

            engine.Reset();

            engine[2, 0] = 'X';
            engine[2, 1] = 'X';
            engine[2, 2] = 'X';

            Assert.AreEqual(true, engine.IsFinished);
            Assert.AreEqual("X", engine.Winer);
        }

        [TestMethod]
        public void TestColumns()
        {
            Engine engine = new Engine();

            engine[0, 0] = 'X';
            engine[1, 0] = 'X';
            engine[2, 0] = 'X';

            Assert.AreEqual(true, engine.IsFinished);
            Assert.AreEqual("X", engine.Winer);

            engine.Reset();

            engine[0, 1] = 'X';
            engine[1, 1] = 'X';
            engine[2, 1] = 'X';

            Assert.AreEqual(true, engine.IsFinished);
            Assert.AreEqual("X", engine.Winer);

            engine.Reset();

            engine[0, 2] = 'X';
            engine[1, 2] = 'X';
            engine[2, 2] = 'X';

            Assert.AreEqual(true, engine.IsFinished);
            Assert.AreEqual("X", engine.Winer);
        }

        [TestMethod]
        public void TestDraw()
        {
            Engine engine = new Engine();

            engine[0, 0] = 'O';
            engine[0, 1] = 'X';
            engine[0, 2] = 'O';

            engine[1, 0] = 'O';
            engine[1, 1] = 'X';
            engine[1, 2] = 'O';

            engine[2, 0] = 'X';
            engine[2, 1] = 'O';
            engine[2, 2] = 'X';

            Assert.AreEqual(true, engine.IsFinished);
            Assert.AreEqual("Nobody", engine.Winer);
        }
    }
}
