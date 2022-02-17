using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries
{
    public class GetGenresQuery
    {
        private readonly IBookStoreDBContext _context;
        private readonly IMapper _mapper;
        public GetGenresQuery(IBookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GenresViewModel> Handle()
        {
            var genres=_context.Genres.Where(x=> x.IsActive).OrderBy(x=>x.ID);
            List<GenresViewModel> returnObj=_mapper.Map<List<GenresViewModel>>(genres);
            return returnObj;
        }
    }
    public class GenresViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}