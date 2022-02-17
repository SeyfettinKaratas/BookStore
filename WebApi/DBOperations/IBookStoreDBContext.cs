using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public interface IBookStoreDBContext
    {
        DbSet<Book> Books {get; set;}
         DbSet<Genre> Genres {get; set;}
         int SaveChanges();
    }
}