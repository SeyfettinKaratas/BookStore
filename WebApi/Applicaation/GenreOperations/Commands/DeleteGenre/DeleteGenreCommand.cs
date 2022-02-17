using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreID { get; set; }
        private readonly IBookStoreDBContext _context;
        public DeleteGenreCommand(IBookStoreDBContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre=_context.Genres.SingleOrDefault(x=>x.ID==GenreID);
            if (genre is null)
            {
                throw InvalidOperationException("Kitap türü bulunamadı!");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }

        private Exception InvalidOperationException(string v)
        {
            throw new NotImplementedException();
        }
    }
}