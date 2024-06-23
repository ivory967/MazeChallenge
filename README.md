# MazeChallenge
This git is a coding challenge where you shoot a laser and based on the trajectory of the laser and mirrors that get in the way will change trajectory.

The solution contains 4 Projects
→ MazeChallenge
  - This is a .Net Core console application to execute the code from MazeChallenge.Shared.
  - In this solution you can upload a file from a Path or just click execute and will run a resource file.
  - 
→ MazeChallenge.AngularUI
  - This is the front page using Angular.
  - Use this to send coordenates and get the result of the input.
  - To Execute Angular both MazeChallenge.AngularUI and MazeChallenge.Api has to be running.

→ MazeChallenge.Shared
  - This contains all logic and clases to execute the Laser

→ MazeChallenge.Api
  - This is the service that angular use to execute the information that at the same time is stored in Shared.
  - Execute this to run AngularUI
