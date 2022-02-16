using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDBcontext _context;
        private readonly IMapper _mapper;
        public CreateAuthorModel model { get; set; }
        public CreateAuthorCommand(BookStoreDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var author=_context.Authors.SingleOrDefault(x=>x.Name==model.Name);
            if (author is not null)
            {
                throw new InvalidOperationException("Yazar zaten mevcut!");
            }
            author=_mapper.Map<Author>(model);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }
    public class CreateAuthorModel
    {
         public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}