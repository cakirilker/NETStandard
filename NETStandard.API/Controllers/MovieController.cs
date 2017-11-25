using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETStandard.Repository;
using NETStandard.Entities;

namespace NETStandard.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        MovieRepository movieRepository;

        public MovieController()
        {
            movieRepository = new MovieRepository();
        }
        // GET: api/Movie
        //[HttpGet]
        //public IEnumerable<Movie> Get()
        //{
        //    return movieRepository.GetAllAsync().Result;
        //}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(movieRepository.GetAllAsync().Result);
        }

        //// GET: api/Movie/5
        //[HttpGet("{id}", Name = "Get")]
        //public Movie Get(int id)
        //{
        //    return movieRepository.GetByIdAsync(id).Result;
        //}

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetById(int id) {
            Movie item = movieRepository.GetByIdAsync(id).Result;
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST: api/Movie
        [HttpPost]
        public IActionResult Create([FromBody]Movie movie)
        {
            if (movie == null) {
                return BadRequest();
            }

            bool x = movieRepository.AddAsync(movie).Result;
            return new ObjectResult(x);
            //return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut]
        public IActionResult Update([FromBody]Movie value)
        {
            bool x = movieRepository.UpdateAsync(value).Result;
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bool x = movieRepository.DeleteAsync(id).Result;
        }
    }
}
