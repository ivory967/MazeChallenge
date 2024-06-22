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
	var map = Maze.InputToMap(filecontent);
	var exitvalues = Maze.GetLaserTrajectory(map);

	Console.WriteLine(exitvalues.ToString());
}



