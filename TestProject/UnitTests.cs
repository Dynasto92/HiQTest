using HiQTest;

namespace TestProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod()
        {
            var gm = new GameManager(5, 5);
            Assert.AreEqual(gm.InterpretCommand("hejsan hoppsan"), false);
            Assert.AreEqual(gm.InterpretCommand("move"), false);
            Assert.AreEqual(gm.InterpretCommand("left"), false);
            Assert.AreEqual(gm.InterpretCommand("right"), false);
            Assert.AreEqual(gm.InterpretCommand("report"), false);
            Assert.AreEqual(gm.InterpretCommand("place"), false);
            Assert.AreEqual(gm.InterpretCommand("place "), false);
            Assert.AreEqual(gm.InterpretCommand("place 1"), false);
            Assert.AreEqual(gm.InterpretCommand("place 1,1"), false);
            Assert.AreEqual(gm.InterpretCommand("place 1,1,"), false);
            Assert.AreEqual(gm.InterpretCommand("place 1,1,something"), false);
            Assert.AreEqual(gm.InterpretCommand("place 1,10,east"), false);
            Assert.AreEqual(gm.InterpretCommand("place 10,1,east"), false);
            Assert.AreEqual(gm.InterpretCommand("place 1,1,east"), true);


            Assert.AreEqual(gm.InterpretCommand("move"), true);
            Assert.AreEqual(gm.InterpretCommand("move"), true);
            Assert.AreEqual(gm.InterpretCommand("move"), true);
            Assert.AreEqual(gm.InterpretCommand("move"), true);
            Assert.AreEqual(gm.InterpretCommand("move"), true);
            Assert.AreEqual(gm.InterpretCommand("move"), true);
            Assert.AreEqual(gm.InterpretCommand("left"), true);
            Assert.AreEqual(gm.InterpretCommand("right"), true);
            Assert.AreEqual(gm.InterpretCommand("report"), true);
            Assert.AreEqual(gm.InterpretCommand("hejsan hoppsan"), false);
            

            var table = new Table(5, 5);    
            Assert.IsTrue(table.IsValidPosition(2, 2));
            Assert.IsFalse(table.IsValidPosition(2, 22));

            var robot = new Robot();
            robot.Place(new InstructionsClass { X = 1, Y = 1, Orientation = Direction.East });
            robot.TurnRight();
            Assert.AreEqual(robot.Orientation, Direction.South);
            robot.Move(table);
            Assert.AreEqual(robot.Y, 0);
        }
    }
}