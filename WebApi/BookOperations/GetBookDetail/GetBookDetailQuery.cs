using System;
using System.Linq;
using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDBcontext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDBcontext dBcontext, IMapper mapper)
        {
            _dbContext = dBcontext;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle(){
             var book=_dbContext.Books.Where(book=> book.ID==BookId).SingleOrDefault();
             if(book is null)
                throw new InvalidOperationException("Kitap bulunamadı!");

            BookDetailViewModel vm=_mapper.Map<BookDetailViewModel>(book);
            // BookDetailViewModel vm=new BookDetailViewModel();
            // vm.Title=book.Title;
            // vm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy");
            // vm.PageCount=book.PageCount;
            // vm.Genre=((GenreEnum)book.GenreID).ToString();

            return vm;
        }
    }
    public class BookDetailViewModel
    {
        public string   Title { get; set; } 
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}