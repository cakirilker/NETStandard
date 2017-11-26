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
        MovieRepository _movieRepository;

        public MovieController()
        {
            _movieRepository = new MovieRepository();
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
            return Ok(_movieRepository.GetAllAsync().Result);
        }

        //// GET: api/Movie/5
        //[HttpGet("{id}", Name = "Get")]
        //public Movie Get(int id)
        //{
        //    return movieRepository.GetByIdAsync(id).Result;
        //}

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetById(int id)
        {
            Movie item = _movieRepository.GetByIdAsync(id).Result;
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
            bool x;
            try
            {
                if (movie == null)
                    return BadRequest();

                 x = _movieRepository.AddAsync(movie).Result;

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok(x);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Movie item)
        {
            try
            {
                if (item == null || item.Id != id)
                    return BadRequest();
                if (_movieRepository.GetByIdAsync(item.Id).Result == null)
                    return NotFound();

                bool x = _movieRepository.UpdateAsync(item).Result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_movieRepository.GetByIdAsync(id).Result == null)
                    return NotFound();

                bool x = _movieRepository.DeleteAsync(id).Result;
            
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return new NoContentResult();
        }
    }
}
