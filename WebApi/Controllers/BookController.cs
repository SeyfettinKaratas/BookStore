using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;

namespace WebApi.Controllers{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDBcontext _context;
        
        public BookController(BookStoreDBcontext context)
        {
            _context=context;
        }

        // private static List<Book> BookList= new List<Book>(){
        //     new Book{
        //         ID=1,
        //         Title="Lean Startup",
        //         GenreID=1, // personal growth
        //         PageCount=200,
        //         PublishDate=new DateTime(
        //             2001,
        //             12,
        //             01)
        //     },
        //     new Book{
        //         ID=2,
        //         Title="Herland",
        //         GenreID=2, // Sience Fiction
        //         PageCount=250,
        //         PublishDate=new DateTime(
        //             2010,
        //             07,
        //             23)
        //     },
        //     new Book{
        //         ID=3,
        //         Title="Dune",
        //         GenreID=2, // Sience Fiction
        //         PageCount=540,
        //         PublishDate=new DateTime(
        //             2002,
        //             05,
        //             23)
        //     }
        // };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList=_context.Books.OrderBy(p=> p.ID).ToList<Book>();
            return bookList;
        }

        [HttpGet ("{id}")]
        public Book GetBooks(int id)
        {
            var book=_context.Books.Where(p=> p.ID==id).SingleOrDefault<Book>();
            return book;
        }

        // [HttpGet ] ---> bu yöntem bir üstteki getbooks metodu ile aynı işlevi görür.
        // public Book Get([FromQuery] string id)
        // {
        //     var book=BookList.Where(p=> p.ID==Convert.ToInt32(id)).SingleOrDefault<Book>();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook ([FromBody] Book newbook)
        {
            var book=_context.Books.SingleOrDefault(x=> x.Title== newbook.Title);
            if(book is not null)
                return BadRequest();
            _context.Books.Add(newbook);
            _context.SaveChanges();
            return Ok();   
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book=_context.Books.SingleOrDefault(x=> x.ID==id);
            if(updatedBook is null)
                return BadRequest();
            book.GenreID=updatedBook.GenreID !=default ? updatedBook.GenreID:book.GenreID;
            book.Title=updatedBook.Title!= default?updatedBook.Title:book.Title;
            book.PageCount=updatedBook.PageCount !=default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate=updatedBook.PublishDate!=default? updatedBook.PublishDate:book.PublishDate;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete ("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book=_context.Books.SingleOrDefault(x=>x.ID==id);
            if(book is null)
                return BadRequest();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();    
        }
    }
}