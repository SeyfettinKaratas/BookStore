using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace TestSetup
{
    //This class work as databese and mapper.
    public class CommonTestFixture
    {
        public BookStoreDBcontext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            //with new options, create new databese in Test 
            var options=new DbContextOptionsBuilder<BookStoreDBcontext>().UseInMemoryDatabase(databaseName:"BookStoreTestDB").Options;
            Context=new BookStoreDBcontext(options);
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.SaveChanges();
            //with new configuration, call mapping in Test 
            Mapper=new MapperConfiguration(cfg=> {cfg.AddProfile<MappingProfile>();}).CreateMapper();
        }
    }
}