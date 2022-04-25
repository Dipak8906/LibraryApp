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
    public class DesignationController : ControllerBase
    {
        private readonly IDesignation _designation;

        public DesignationController(IDesignation designation)
        {
            _designation = designation;
        }
        // GET: api/<DesignationController>
        [HttpGet]
        public async Task<IEnumerable<Designation>> Get()
        {
            return await _designation.GetDesignationAsync();
        }

        // GET api/<DesignationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Designation designation = await _designation.GetDesignation(id);
            if (designation == null)
            {
                return NotFound("Not found the designation");
            }
            return Ok(designation);
        }

        // POST api/<DesignationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Designation designation)
        {
            await _designation.AddDesignation(designation);
            return Ok("Successfully add designation");
        }

        // PUT api/<DesignationController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Designation designation)
        {
            Designation designation1 = await _designation.UpdateDesignationAsync(designation);
            if (designation1 == null)
            {
                return NotFound("Not found the designation");
            }
            return Ok(designation1);
        }

        // DELETE api/<DesignationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _designation.DeleteDesignationAsync(id);
            return Ok("Successfully delete designation");
        }
    }
}
