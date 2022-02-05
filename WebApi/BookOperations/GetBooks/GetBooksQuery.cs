using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBcontext _dbContext;
         private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDBcontext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
             var bookList=_dbContext.Books.OrderBy(p=> p.ID).ToList<Book>();
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