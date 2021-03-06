using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.UpdateBook{
    public class UpdateBookCommand{
        private readonly IBookStoreDBContext _dbContext;
        public int BookId { get; set; }
        public UpdateBookViewModel Model { get; set; }
        public UpdateBookCommand(IBookStoreDBContext dbContext)
        {
            _dbContext=dbContext;
        }
        public void Handle()
        {
            var book=_dbContext.Books.SingleOrDefault(x=> x.ID==BookId);
            if(book is null)
                throw new InvalidOperationException("Kitap bulunamad─▒!");
            book.GenreID=Model.GenreId !=default ? Model.GenreId:book.GenreID;
            book.Title=Model.Title!= default ? Model.Title:book.Title;
            //book.PageCount=updatedBook.PageCount !=default ? updatedBook.PageCount : book.PageCount;
           // book.PublishDate=updatedBook.PublishDate!=default? updatedBook.PublishDate:book.PublishDate;

            _dbContext.SaveChanges();
        }

    }
    public class UpdateBookViewModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
    }
}