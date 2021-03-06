using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.DBOperations;

namespace WebApi.Controllers{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly IBookStoreDBContext _context;
        private readonly IMapper _mapper;

        public BookController(IBookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public IActionResult GetBooks()
        {
            GetBooksQuery query=new GetBooksQuery(_context,_mapper);
            var result=query.Handle();
            return Ok(result);
        }

        [HttpGet ("{id}")]
        public IActionResult GetBooks(int id)
        {
            // var book=_context.Books.Where(p=> p.ID==id).SingleOrDefault<Book>();
            // return book;
           
            // try
            // {
            //    GetBookDetailQuery query=new GetBookDetailQuery(_context,_mapper);
            //     query.BookId=id;
            //     GetBookDetailQueryValidator validator=new GetBookDetailQueryValidator();
            //     validator.ValidateAndThrow(query);
            //     result= query.Handle(); 
            // }
            // catch (Exception ex)
            // {
                
            //     return BadRequest(ex.Message);
            // }
            BookDetailViewModel result;
            GetBookDetailQuery query=new GetBookDetailQuery(_context,_mapper);
            query.BookId=id;
            GetBookDetailQueryValidator validator=new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result= query.Handle(); 
            return Ok(result);

        }

        // [HttpGet ] ---> bu y??ntem bir ??stteki getbooks metodu ile ayn?? i??levi g??r??r.
        // public Book Get([FromQuery] string id)
        // {
        //     var book=BookList.Where(p=> p.ID==Convert.ToInt32(id)).SingleOrDefault<Book>();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook ([FromBody] CreateBookModel newbook)
        {
            // var book=_context.Books.SingleOrDefault(x=> x.Title== newbook.Title);
            // if(book is not null)
            //     return BadRequest();
            // _context.Books.Add(newbook);
            // _context.SaveChanges();
            // return Ok();   
            

            //----Try-catch blo??u middleware metodu kullan??larak kapat??ld??.
            // try
            // {
            //     command.Model=newbook;
            //     CreateBookCommandValidator validator=new CreateBookCommandValidator();

            //     validator.ValidateAndThrow(command);
            //     command.Handle();

            //    // ValidationResult result=validator.Validate(command);
            //     // if (!result.IsValid)
            //     // {
            //     //     foreach (var item in result.Errors)
            //     //     {
            //     //         Console.WriteLine("??zellik "+item.PropertyName+"Error Message: "+item.ErrorMessage);
            //     //     }                    
            //     // }
            //     // else
            //     //     {
            //     //          command.Handle();
            //     //     }
               
 
            // }
            // catch (Exception ex)
            // {                
            //    return BadRequest(ex.Message);
            // }
            CreateBookCommand command=new CreateBookCommand(_context,_mapper);
            command.Model=newbook;
            CreateBookCommandValidator validator=new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookViewModel updatedBook)
        {
            // var book=_context.Books.SingleOrDefault(x=> x.ID==id);
            // if(updatedBook is null)
            //     return BadRequest();
            // book.GenreID=updatedBook.GenreID !=default ? updatedBook.GenreID:book.GenreID;
            // book.Title=updatedBook.Title!= default?updatedBook.Title:book.Title;
            // book.PageCount=updatedBook.PageCount !=default ? updatedBook.PageCount : book.PageCount;
            // book.PublishDate=updatedBook.PublishDate!=default? updatedBook.PublishDate:book.PublishDate;

            // _context.SaveChanges();

           
            // try
            // {
            //      UpdateBookCommand command=new UpdateBookCommand(_context);
            //      command.BookId=id;
            //      command.Model=updatedBook;
            //      UpdateBookCommandValidator validator=new UpdateBookCommandValidator();
            //      validator.ValidateAndThrow(command);
            //      command.Handle();
            // }
            // catch (Exception ex)
            // {
            //     return BadRequest(ex.Message);
            // }
            UpdateBookCommand command=new UpdateBookCommand(_context);
            command.BookId=id;
            command.Model=updatedBook;
            UpdateBookCommandValidator validator=new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete ("{id}")]
        public IActionResult DeleteBook(int id)
        {
            // var book=_context.Books.SingleOrDefault(x=>x.ID==id);
            // if(book is null)
            //     return BadRequest();
            // _context.Books.Remove(book);
            // _context.SaveChanges();
            // try
            // {
            //     DeleteBookCommand command=new DeleteBookCommand(_context);
            //     command.BookId=id;
            //     DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
            //     validator.ValidateAndThrow(command);
            //     command.Handle();

            // }
            // catch (Exception ex)
            // {
            //     return BadRequest(ex.Message);
            // }
            DeleteBookCommand command=new DeleteBookCommand(_context);
            command.BookId=id;
            DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();    
        }
    }
}