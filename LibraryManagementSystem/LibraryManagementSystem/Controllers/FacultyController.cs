using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{

   
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFaculty _faculty;

        public FacultyController(IFaculty faculty)
        {
            _faculty = faculty;
        }
        // GET: api/<FacultyController>
        [HttpGet]
        public async Task<IEnumerable<Faculty>> Get()
        {
            return await _faculty.GetFacultyAsync();
        }
        // GET api/<FacultyController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Faculty faculty = await _faculty.GetFaculty(id);
            if (faculty == null)
            {
                return NotFound("Not found the faculty");
            }
            return Ok(faculty);
        }

        // POST api/<FacultyController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Faculty faculty)
        {
            await _faculty.AddFaculty(faculty);
            return Ok("Successfully add faculty");
        }

        // PUT api/<FacultyController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Faculty faculty)
        {
            Faculty faculty1 = await _faculty.UpdateFacultyAsync(faculty);
            if (faculty1 == null)
            {
                return NotFound("Not found the faculty");
            }
            return Ok(faculty1);
        }

        // DELETE api/<FacultyController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _faculty.DeleteFacultyAsync(id);
            return Ok("Successfully delete faculty");
        }
    }
}
