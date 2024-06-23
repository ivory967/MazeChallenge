using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallenge.Shared.Dto
{
    public class ResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class ResultDtoObject<T> : ResultDto
    {
        public T? Data { get; set; }
    }
}
