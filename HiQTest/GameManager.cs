namespace HiQTest
{
    public class GameManager
    {
        public Table Table { get; set; }
        public Robot Robot { get; set; }

        public GameManager(int width, int height)
        {
            Table = new Table(width, height);
            Robot = new Robot();
        }

        public bool TryPlacingRobot(InstructionsClass instructions)
        {
            if (Table.IsValidPosition(instructions.X, instructions.Y))
            {
                Robot.Place(instructions);
                Console.WriteLine($"Robot placed at {instructions.X}, {instructions.Y} facing {instructions.Orientation}");
                return true;
            }
            else
            {
                Console.WriteLine("Those coordinates are outside the table.");
                return false;
            }
        }

        public bool InterpretCommand(string result)
        {
            if (result.ToLower().Contains("place") && TryParsePlaceCommand(result, out InstructionsClass instructions))
            {
                return TryPlacingRobot(instructions);
            }

            if (Robot != null && Robot.IsPlaced == true)
            {
                switch (result.ToLower())
                {
                    case "right":
                    case "rt":
                        Robot.TurnRight();
                        return true;
                    case "left":
                    case "l":
                        Robot.TurnLeft();
                        return true;
                    case "report":
                    case "r":
                        Robot.Report();
                        return true;
                    case "move":
                    case "m":
                        Robot.Move(Table);
                        return true;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }

            return false;
        }

        private bool TryParsePlaceCommand(string result, out InstructionsClass instructions)
        {
            instructions = new InstructionsClass();
            var splitString = result.Split(' ');
            if (splitString.Length == 2)
            {
                var coordinates = splitString[1].Split(',');
                if (coordinates.Length == 3)
                {
                    var x = -1;
                    var y = -1;
                    var orientation = Direction.Invalid;

                    if (int.TryParse(coordinates[0], out var xCoordinate))
                    {
                        x = xCoordinate;
                    }

                    if (int.TryParse(coordinates[1], out var yCoordinate))
                    {
                        y = yCoordinate;
                    }

                    if (int.TryParse(coordinates[2], out var directionInt) == false &&
                        Enum.TryParse(typeof(Direction), coordinates[2], true, out object? direction))
                    {
                        orientation = (Direction)direction;
                    }

                    if (x > -1 && y > -1 && orientation != Direction.Invalid)
                    {
                        instructions.X = x;
                        instructions.Y = y;
                        instructions.Orientation = orientation;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
