// See https://aka.ms/new-console-template for more information
using MazeChallenge.Properties;
using MazeChallenge.Shared;
using System.IO;
using System.Reflection;
Launch();
void Launch()
{
	//reading the text file to get the values
	string[] filecontent = File.ReadAllLines("D:\\MazeTestCase2.txt");

    //use this to read the file from resources, i had to look up for empty spaces when is from resources \n \r clean the rows.
    string[] fileFromResources = Resources.MazeTestCase.Split(new[] {'\n','\r' },StringSplitOptions.RemoveEmptyEntries);

	 //A Sample Text File
		//1,0V
		//--br--
		//1,2RB
		//3,2L
		//--br--
		//5,4
		//--br--


	//if you only want the map use this. I keep it this way in case in the future there is a need to draw the map or have a map object.
	//var map = Maze.InputToMap(filecontent);
	//assuming you have multiple maps we can shot more than one using this one. (note: if i have time i need to make this async)
	//var exitvalues = Maze.GetLaserTrajectory(map);
	//assuming you just one the information here is the method
	var trajectory = Maze.GetLaserTrajectory(fileFromResources);
	if (!trajectory.Success || trajectory.Data==null) {
		Console.WriteLine(trajectory.Message);
		//save a log with the error?
	}
	else
	{
        var result = $"Dimensions of this board are {trajectory.Data.Height} x {trajectory.Data.Width} " +
			Environment.NewLine +
			$"start position of the laser is {trajectory.Data.Start_X}-{trajectory.Data.Start_Y} and Orientation is {trajectory.Data.Orientation} " +
			Environment.NewLine +
			$"and exit point is {trajectory.Data.End_X}-{trajectory.Data.End_Y}";
        Console.WriteLine(result);
    }

		
}



