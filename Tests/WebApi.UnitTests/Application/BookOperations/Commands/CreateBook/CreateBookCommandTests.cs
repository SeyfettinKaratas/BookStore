using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDBcontext _context;
        private readonly IMapper _mapper;
        public CreateBookCommandTests(CommonTestFixture textFixture)
        {
            _context=textFixture.Context;
            _mapper=textFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var book=new Book(){
                Title="Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",
                PageCount=100,
                PublishDate=new System.DateTime(1994,4,4),
                GenreID=1
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command=new CreateBookCommand(_context,_mapper);
            command.Model=new CreateBookModel(){Title=book.Title};

            //act and assert
            FluentActions
            .Invoking(()=>command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut!");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            // Given
            CreateBookCommand command=new CreateBookCommand(_context,_mapper);
            CreateBookModel model=new CreateBookModel(){
                Title="Hobbit",
                Pagecount=300,
                PublishDate=DateTime.Now.Date.AddYears(-10),
                GenreID=1
                };
                command.Model=model;
            // When 
            FluentActions.Invoking(()=>command.Handle()).Invoke();
            // Then
            var book=_context.Books.SingleOrDefault(book=>book.Title==model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.Pagecount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreID.Should().Be(model.GenreID);

        }
    }
}