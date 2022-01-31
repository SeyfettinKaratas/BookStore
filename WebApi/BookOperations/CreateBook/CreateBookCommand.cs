using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get; set;}
        private readonly BookStoreDBcontext _dbContext;
        public CreateBookCommand(BookStoreDBcontext dbContext)
        {
           _dbContext=dbContext; 
        }
        public void Handle()
        {
            var book=_dbContext.Books.SingleOrDefault(x=> x.Title== Model.Title);
            if(book is not null)
                throw new InvalidOperationException("Kitap zaten mevcut!");
            book=new Book();
            book.Title=Model.Title;
            book.PublishDate=Model.PublishDate;
            book.PageCount=Model.Pagecount;
            book.GenreID=Model.GenreID; 
             
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