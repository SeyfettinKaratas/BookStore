using AutoMapper;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Queries;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            //Burada Genre class ı ile rtık GenreEnum kullanmaya gerek kalmadan kaynak olarak gösterim yapıyoruz.
            //CreateMap<Book, BookDetailViewModel>().ForMember(dest=> dest.Genre, opt=> opt.MapFrom(src=> ((GenreEnum)src.GenreID).ToString()));
            CreateMap<Book, BookDetailViewModel>().ForMember(dest=> dest.Genre, opt=> opt.MapFrom(src=> src.Genre.Name));
            //CreateMap<Book, BooksViewModel>().ForMember(dest=> dest.Genre, opt=> opt.MapFrom(src=> ((GenreEnum)src.GenreID).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest=> dest.Genre, opt=> opt.MapFrom(src=> src.Genre.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
        }
    }
}