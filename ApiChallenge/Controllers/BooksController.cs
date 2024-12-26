using ApiChallenge.Models;
using ApiChallenge.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiChallenge.Controllers
{
    [Route("api")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBooksService service { get; set; }
        public BooksController(IBooksService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            ICollection<Book> list = service.GetBook();
            if (list.Count == 0)
            {
                return NotFound();
            }
            return Ok(list);
        }
        [HttpGet("{id}")] 
        public IActionResult GetBook(int id)
        {
            Book car = service.GetBookById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
        [HttpGet("search")] 
        public IActionResult GetBook([FromQuery] int id, [FromQuery] string titre)
        {
            ICollection<Book> books = service.GetBookByIdAndTitre(id, titre);
            if (books.Count == 0)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpPost]
        public IActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid) 
            {
                return UnprocessableEntity();
            }
            service.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            if (id != book.id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            service.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (service.GetBookById(id) == null)
            {
                return NotFound();
            }
            service.Remove(id);
            return NoContent();
        }
    }
}
