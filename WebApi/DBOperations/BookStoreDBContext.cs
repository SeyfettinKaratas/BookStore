using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class BookStoreDBcontext: DbContext
    {
        public BookStoreDBcontext(DbContextOptions<BookStoreDBcontext>options):base(options)
        {
            
        }
        public DbSet<Book> Books {get; set;}
    }
}