using HiQTest;

var result = "";
var gm = new GameManager(5, 5);
var validCommand = false;

// This path worked for me but you may need to adjust it
var lines = File.ReadLines("../../../Instructions.txt");

// If there are no instructions in the file, prompt the user for input
if (lines.Any() == false)
{
    do
    {
        Console.WriteLine("First you must enter the robot's position and orientation:");
        result = Console.ReadLine();
        validCommand = result.ToLower().Contains("place") && gm.InterpretCommand(result);
        Console.WriteLine("");
    }
    while (validCommand == false);

    while (true)
    {
        Console.WriteLine("Enter a command:");

        result = Console.ReadLine();
        gm.InterpretCommand(result);

        Console.WriteLine("");
    }
}
else
{
    for (int i = 0; i < lines.Count(); i++)
    {
        var command = lines.ToList()[i];

        if (validCommand == false && i != lines.Count() - 1)
        {
            Console.WriteLine("First you must enter the robot's position and orientation:");
            validCommand = command.ToLower().Contains("place") && gm.InterpretCommand(command);
            Console.WriteLine("");
        }
        else if (validCommand)
        {
            Console.WriteLine($"Command {command} entered:");
            gm.InterpretCommand(command);
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("No place command present");
            break;
        }
    }
}
