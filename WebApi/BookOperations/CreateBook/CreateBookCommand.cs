using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get; set;}
        private readonly BookStoreDBcontext _dbContext;
        private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDBcontext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var book=_dbContext.Books.SingleOrDefault(x=> x.Title== Model.Title);
            if(book is not null)
                throw new InvalidOperationException("Kitap zaten mevcut!");

            book=_mapper.Map<Book>(Model);    
            //book=new Book();
            // book.Title=Model.Title;
            // book.PublishDate=Model.PublishDate;
            // book.PageCount=Model.Pagecount;
            // book.GenreID=Model.GenreID; 
             
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
       

        }
    }
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreID { get; set; }
        public int Pagecount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}