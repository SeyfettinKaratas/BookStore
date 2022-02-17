using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDBContext _dbContext;
         private readonly IMapper _mapper;
        public GetBooksQuery(IBookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            //Include ile Genre Classı buraya eklendi.
             var bookList=_dbContext.Books.Include(x=>x.Genre).OrderBy(p=> p.ID).ToList<Book>();
             List<BooksViewModel> vm=_mapper.Map<List<BooksViewModel>>(bookList);
            //  List<BooksViewModel> vm=new List<BooksViewModel>();
            //  foreach (var book in bookList)
            //  {
            //      vm.Add(new BooksViewModel()
            //      {
            //          Title=book.Title,
            //          Genre=((GenreEnum)book.GenreID).ToString(),
            //          PublishDate=book.PublishDate.Date.ToString("dd/MM/yyy"),
            //          PageCount=book.PageCount
            //      });
            //  }
            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }    
        public string PublishDate { get; set; } 
        public string  Genre { get; set; }
    }
}