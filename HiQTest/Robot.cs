namespace HiQTest
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Orientation { get; set; }
        public bool IsPlaced { get; set; }

        public void Place(InstructionsClass instructions)
        {
            X = instructions.X;
            Y = instructions.Y;
            Orientation = instructions.Orientation;
            IsPlaced = true;
        }

        // Could also have used Math.Min/Math.Max to ensure the values are within the table
        public void Move(Table table)
        {
            var oldValuesBackup = new int[] { X, Y };

            switch (Orientation)
            {
                case Direction.North:
                    Y++;
                    break;
                case Direction.South:
                    Y--;
                    break;
                case Direction.East:
                    X++;
                    break;
                case Direction.West:
                    X--;
                    break;
            }

            if (table.IsValidPosition(X, Y))
            {
                Console.WriteLine("Robot has moved!");
            }
            else
            {
                Console.WriteLine("Can't move outside the table");
                X = oldValuesBackup[0];
                Y = oldValuesBackup[1];
            }
        }

        public void TurnLeft()
        {
            switch (Orientation)
            {
                case Direction.North:
                    Orientation = Direction.West;
                    break;
                case Direction.West:
                    Orientation = Direction.South;
                    break;
                case Direction.South:
                    Orientation = Direction.East;
                    break;
                case Direction.East:
                    Orientation = Direction.North;
                    break;
            }

            Console.WriteLine("Robot turned left");
        }

        public void TurnRight()
        {
            switch (Orientation)
            {
                case Direction.North:
                    Orientation = Direction.East;
                    break;
                case Direction.East:
                    Orientation = Direction.South;
                    break;
                case Direction.South:
                    Orientation = Direction.West;
                    break;
                case Direction.West:
                    Orientation = Direction.North;
                    break;
            }

            Console.WriteLine("Robot turned right");
        }

        public void Report()
        {
            Console.WriteLine($"{X},{Y},{Orientation}");
        }
    }

    public enum Direction
    {
        Invalid,
        North,
        East,
        South,
        West
    }
}
