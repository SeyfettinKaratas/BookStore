using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class BookStoreDBcontext: DbContext, IBookStoreDBContext 
    {
        public BookStoreDBcontext(DbContextOptions<BookStoreDBcontext>options):base(options)
        {
            
        }
        public DbSet<Book> Books {get; set;}
        public DbSet<Genre> Genres {get; set;}
        public DbSet<Author> Authors { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}