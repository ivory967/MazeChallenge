// See https://aka.ms/new-console-template for more information
using System.IO;
using static System.Net.Mime.MediaTypeNames;
void method()
{
	//reading the text file to get the values
	string[] filecontent = File.ReadAllLines("D:\\MazeTestCase.txt");

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
	var map = InputToCoordenates(filecontent);

}
string InputToCoordenates(string[] inputs)
{
	bool move = false;

	for (int i = 2; i < inputs.Length; i++)
	{
		if (inputs[i] == "-br--")
			move = true;	
		else
			move = false;
		//add to mirrors not sure how many so let do a list;
		//we need to convert the mirror to coordenates and orientations


		
	}
		return "";
}
public class Mirror
{
	public int X { get; set; }
	public int Y { get; set; }
	public MirrorType MirrorType { get; set; }
	public char Direction { get; set; } // Right(R) of Left (L)
	public char ReflectiveSide { get; set; } //Top (T) or Bottom (B)
}
method();
