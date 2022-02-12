using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries
{
    public class GetGenreDetailQuery
    {
        public int GenreID { get; set; }
        private readonly BookStoreDBcontext _context;
        private readonly IMapper _mapper;
        public GetGenreDetailQuery(BookStoreDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GenreDetailViewModel Handle()
        {
            var genre=_context.Genres.SingleOrDefault(x=> x.IsActive && x.ID== GenreID);
            if (genre is null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }
            var returnObj=_mapper.Map<GenreDetailViewModel>(genre);
            return returnObj;
        }
    }
    public class GenreDetailViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}