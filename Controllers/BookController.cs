using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyBookApi.Models;
using MyBookApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository repository;

        public BookController(IBookRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("")]
        public async Task<IActionResult> getallBooks()
        {
            var result =  await repository.GetAllBooks();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> getbookbyId([FromRoute]int id)
        {
            var result = await repository.GetBookById(id);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody]BookModel model)
        {
            var result = await repository.AddBook(model);
            return CreatedAtAction(nameof(getbookbyId),new { id = result, controller = "book" }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateAll([FromBody] BookModel model,[FromRoute]int id)
        {
            await repository.UpdateAll(model,id);
            return Ok();
        }

        //[HttpPatch("{id}")]
        //public async Task<IActionResult> updatePatch([FromBody] JsonPatchDocument model, [FromRoute] int id)
        //{
        //    await repository.updatePatch(id, model);
        //    return Ok();
        //}
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete( [FromRoute] int id)
        {
            await repository.Delete(id);
            return Ok();
        }



    }
}
