// See https://aka.ms/new-console-template for more information
using MazeChallenge.Shared;
using System.IO;
method();
void method()
{
	//reading the text file to get the values
	string[] filecontent = File.ReadAllLines("D:\\MazeTestCase2.txt");

	 //A Sample Text File
		//1,0V
		//--br--
		//1,2RB
		//3,2L
		//--br--
		//5,4
		//--br--


    if (filecontent.Where(a=>a.Contains("--br--")).Count()!=3)
	{
		Console.WriteLine("Invalid text file");
	}
	//if you only want the map use this. I keep it this way in case in the future there is a need to draw the map or have a map object.
	//var map = Maze.InputToMap(filecontent);
	//assuming you have multiple maps we can shot more than one using this one. (note: if i have time i need to make this async)
	//var exitvalues = Maze.GetLaserTrajectory(map);
	//assuming you just one the information here is the method
	var trajectory = Maze.GetLaserTrajectory(filecontent);
	if (trajectory == null) {
		Console.WriteLine("Error ocurred while processing your request");
		//save a log with the error?
	}
	else
	{
        var result = $"Dimensions of this board are {trajectory.Height} x {trajectory.Width} " +
			Environment.NewLine +
			$"start position of the laser is {trajectory.Start_X}-{trajectory.Start_Y} and Orientation is {trajectory.Orientation} " +
			Environment.NewLine +
			$"and exit point is {trajectory.End_X}-{trajectory.End_Y}";
        Console.WriteLine(result);
    }

		
}



