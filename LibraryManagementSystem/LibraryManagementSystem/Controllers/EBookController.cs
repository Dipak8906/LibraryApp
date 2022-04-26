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
    public class EBookController : ControllerBase
    {
        private readonly IEbook _eBook;

        public EBookController(IEbook eBook)
        {
            _eBook = eBook;
        }
        // GET: api/<EBookController>
        [HttpGet]
        public async Task<IEnumerable<Ebook>> Get()
        {
            return await _eBook.GetEbookAsync();
        }

        // GET api/<EBookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Ebook eBook = await _eBook.GetEbook(id);
            if (eBook == null)
            {
                return NotFound("Not found the EBook");
            }
            return Ok(eBook);
        }

        // POST api/<EBookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ebook eBook)
        {
            await _eBook.AddEbook(eBook);
            return Ok("Successfully add EBook");
        }

        // PUT api/<EBookController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateEbookAsync([FromBody] Ebook eBook)
        {
            var eBook1 = await _eBook.UpdateEbookAsync(eBook);
            if (eBook1 == null)
            {
                return NotFound("Not found the EBook");
            }
            return Ok(eBook1);
        }

        // DELETE api/<EBookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _eBook.DeleteEbookAsync(id);
            return Ok("Successfully delete EBook");
        }
    }
}
