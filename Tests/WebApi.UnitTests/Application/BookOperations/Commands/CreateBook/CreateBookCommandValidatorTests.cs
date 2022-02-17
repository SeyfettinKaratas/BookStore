using System;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lord of the Rings",0,0)]
        [InlineData("Lord of the Rings",0,1)]
        [InlineData("Lord of the Rings",0,0)]
        [InlineData("",0,0)]
        [InlineData("",100,1)]
        [InlineData("",0,1)]
        [InlineData("Lor",100,1)]
        [InlineData("Lord ",100,0)]
        [InlineData("Lord of the Rings",0,0)]
        [InlineData(" ",100,1)]
       public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title,int pageCount,int genreId)
       {   
           //arrange
           CreateBookCommand command=new CreateBookCommand(null,null);
           command.Model=new CreateBookModel()
           {
               Title=title,
               Pagecount=pageCount,
               PublishDate=DateTime.Now.Date.AddYears(-1),
               GenreID=genreId
           };
           //act
           CreateBookCommandValidator validator=new CreateBookCommandValidator();
           var result=validator.Validate(command);
            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

       }

       [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
       {   
          //arrange
            CreateBookCommand command=new CreateBookCommand(null,null);
            command.Model=new CreateBookModel()
            {
               Title="Lord of the Rings",
               Pagecount=100,
               PublishDate=DateTime.Now.Date,
               GenreID=1
          };
           //act
          CreateBookCommandValidator validator=new CreateBookCommandValidator();
           var result=validator.Validate(command);
           //assert
            result.Errors.Count.Should().BeGreaterThan(0);
       }
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
       {   
          //arrange
            CreateBookCommand command=new CreateBookCommand(null,null);
            command.Model=new CreateBookModel()
            {
               Title="Lord of the Rings",
               Pagecount=100,
               PublishDate=DateTime.Now.Date.AddYears(-2),
               GenreID=1
          };
           //act
          CreateBookCommandValidator validator=new CreateBookCommandValidator();
           var result=validator.Validate(command);
           //assert
            result.Errors.Count.Should().Be(0);
       }




    //this method controlling just one case!!!

    //      [Fact]
    //    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
    //    {   
    //        //arrange
    //        CreateBookCommand command=new CreateBookCommand(null,null);
    //        command.Model=new CreateBookModel()
    //        {
    //            Title="",
    //            Pagecount=0,
    //            PublishDate=DateTime.Now.Date,
    //            GenreID=0
    //        };
    //        //act
    //        CreateBookCommandValidator validator=new CreateBookCommandValidator();
    //        var result=validator.Validate(command);
    //         //assert
    //         result.Errors.Count.Should().BeGreaterThan(0);

    //    }
    }
}