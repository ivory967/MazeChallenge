using MazeChallenge.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MazeChallenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MazeController : ControllerBase
    {
       
        public MazeController() { }

        [HttpPost("GetMazeMap")]
        public IActionResult GetMazeMap([FromBody] string[] inputText)
        {
            var getMap = Maze.InputToMap(inputText);
            return Ok(getMap);
        }
        //has to set this as post to allow the string[] and has to use [fromBody]
        [HttpPost("GetLaserTrajectory")]
        public IActionResult GetLaserTrajectory([FromBody] string[] inputText)
        {
            var trajectory = Maze.GetLaserTrajectory(inputText);
            if (!trajectory.Success)
                NotFound(trajectory);

            return Ok(trajectory.Data);
        }
    }
}
