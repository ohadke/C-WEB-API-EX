using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesContoller : ControllerBase
    {
        private static List<string> _MoviesList = new List<string>
        {
            "Pokemon",
            "Ace-Ventura",
            "Fight Club",
            "Deadpool",
            "Avengers"
        };

        [HttpGet]
        public IEnumerable<string> GetAll([FromQuery] string startsWith)
        {
            var prefix = startsWith ?? "";

            return _MoviesList.Where(m => m.StartsWith(prefix));
        }

        [HttpGet("{index}")]
        public string GetFromIndex(int index)
        {
            if (_MoviesList.Count > index)
            {
                return _MoviesList[index];
            }

            return "Out of Range";
        }

        [HttpPost]
        public void Add([FromBody] string newMovie)
        {
            _MoviesList.Add(newMovie);
        }
        
        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            if (_MoviesList.Count > index)
            {
                _MoviesList.RemoveAt(index);
            }
        }

        [HttpPut("{index}")]
        public void Replace(int index, [FromBody]string movie)
        {
            _MoviesList[index] = movie;
        }
    }
}
